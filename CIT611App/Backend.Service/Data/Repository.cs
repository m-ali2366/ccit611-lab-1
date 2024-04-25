
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Backend.Service.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Reflection;
using Backend.Service.Common.Views;

namespace Backend.Service.Data
{
    public class Repository<T> where T : BaseModel, new()
    {
        private readonly string userId;
        public readonly DbSet<T> dbSet;
        protected readonly EntitiesContext context;
        protected string[] defaultExcludedEditProperties = new string[]
        { "CreatedDate", "CreatedBy", "IsDeleted" };
        protected string[] defaultExcludedDeleteProperties = new string[]
        { "CreatedDate", "CreatedBy" };
        public Repository(EntitiesContext _context, UserState userState)
        {
            context = _context;
            dbSet = context.Set<T>();
            userId = userState?.Claims?.FirstOrDefault(c=> c.Key.ToLower() == "userid").Value.ToString();
        }
        public T Add(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = userId;
            dbSet.Add(entity);
            return entity;
        }
        public async Task<T> AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = userId;
            await dbSet.AddAsync(entity);
            return entity;
        }
        public bool IsDeleted(T entity)
        {
            return GetWithDeleted().FirstOrDefault(e => e.ID == entity.ID)?.IsDeleted ?? true;
        }
        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            SaveIncluded(entity, nameof(entity.IsDeleted), nameof(entity.UpdatedBy), nameof(entity.UpdatedDate));
        }
        public void Delete(string id)
        {
            T entity = new T();
            entity.ID = id;
            Delete(entity);
        }
        public IQueryable<T> Get()
        {
            return dbSet.Where(entity => !entity.IsDeleted);
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Get().Where(predicate);
        }
        public int BatchDelete(Expression<Func<T, bool>> predicate, int day = 90, int rows = 1000)
        {
            return GetWithDeleted().Where(predicate).ExecuteDelete();
        }
        public int BatchDeleteWithRows(Expression<Func<T, bool>> predicate, int rows = 1000)
        {
            return GetWithDeleted().Where(predicate).Take(rows).ExecuteDelete();
        }
        public int BatchDelete(int days = 60, int rows = 1000)
        {
            DateTime fromDate = DateTime.Now.AddDays(-days);
            return GetWithDeleted().Where(x => x.CreatedDate < fromDate).Take(rows).ExecuteDelete();
        }
        public int BulkUpdate(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
        {
            return Get().ExecuteUpdate(setPropertyCalls);
        }
        public async Task<int> BulkUpdateAsync(Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls)
        {
            return await Get().ExecuteUpdateAsync(setPropertyCalls);
        }
        public T Get(string id)
        {
            return Get().FirstOrDefault(item => item.ID == id);
        }
        public IQueryable<T> GetWithDeleted()
        {
            return dbSet;
        }
        public bool ExistsLocal(T entity)
        {
            return dbSet.Local.Any(e => e == entity);
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Get().Where(predicate).FirstOrDefault();
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Get().Where(predicate).FirstOrDefaultAsync();
        }
        public T FirstOrDefault(string id)
        {
            return FirstOrDefault(item => item.ID == id);
        }
        public T First(Expression<Func<T, bool>> predicate)
        {
            return Get().Where(predicate).First();
        }
        public T First(string id)
        {
            return First(item => item.ID == id);
        }
        public T FirstOrDefault()
        {
            return Get().FirstOrDefault();
        }
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return Get().Any(predicate);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Get().AnyAsync(predicate);
        }
        public void Update(T entity)
        {
            if (string.IsNullOrEmpty(entity.ID))
                return;
            SaveExcluded(entity, nameof(BaseModel.ID), nameof(BaseModel.CreatedBy), nameof(BaseModel.CreatedDate), nameof(BaseModel.IsDeleted));
        }
        private void RemoveIfAttachedToContext(T entity)
        {
            var local = dbSet.Local.FirstOrDefault(entry => entry.ID.Equals(entity.ID));
            if (local != null) context.Entry(local).State = EntityState.Detached;
        }
        public virtual void SaveIncluded(T entity, params string[] properties)
        {

            EntityEntry entry = context.ChangeTracker.Entries<T>().FirstOrDefault(e => e.Entity.ID == entity.ID);
            if (entry is null)
                entry = context.Entry(entity);

            var entityProperties = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in entityProperties)
            {
                if (properties.Contains(property.Name))
                {
                    entry.Property(property.Name).CurrentValue = property.GetValue(entity);
                    entry.Property(property.Name).IsModified = true;
                }
            }
            entry.Property(nameof(entity.UpdatedDate)).CurrentValue = DateTime.Now;
            entry.Property(nameof(entity.UpdatedBy)).CurrentValue = userId;
        }
        public virtual void SaveExcluded(T entity, params string[] properties)
        {
            if (string.IsNullOrEmpty(entity.ID))
                return;
            List<string> excludedProperties = properties.ToList();
            excludedProperties.Add(nameof(BaseModel.ID));
            excludedProperties.Add(nameof(BaseModel.CreatedBy));
            excludedProperties.Add(nameof(BaseModel.CreatedDate));
            excludedProperties.Add(nameof(BaseModel.IsDeleted));
            RemoveIfAttachedToContext(entity);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = userId;
            var entry = context.Entry(entity);
            foreach (var prop in entry.Properties)
            {
                if (excludedProperties.Contains(prop.Metadata.Name))
                    prop.IsModified = false;
                else
                    prop.IsModified = true;
            }
        }
        public string GetLastID()
        {
            return GetWithDeleted().OrderByDescending(item => item.ID).FirstOrDefault()?.ID ?? "";
        }
        public async Task<T> LastOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await Get(predicate).OrderByDescending(x => x.ID).FirstOrDefaultAsync();
        }
        public IQueryable<T> GetWithTracking(Expression<Func<T, bool>> predicate)
        {
            return Get().Where(predicate).AsTracking();
        }
    }
}

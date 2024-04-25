
using Microsoft.EntityFrameworkCore;
using Backend.Service.Data.Extensions;
using Backend.Service.Models;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Diagnostics;


namespace Backend.Service.Data
{
    public class EntitiesContext : DbContext
    {

     
        public virtual DbSet<Profile> Profiles { get; set; }
      
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAction> UserActions { get; set; }

     

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), type => type != typeof(BaseModelConfiguration));
            modelBuilder.RemoveCascadeDeleteConvention();

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CIT611App"))
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .LogTo(log => Debug.WriteLine(log), Microsoft.Extensions.Logging.LogLevel.Information)
                    .EnableSensitiveDataLogging()
;
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}

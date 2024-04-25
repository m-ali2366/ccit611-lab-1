using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Backend.Service.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder RemoveCascadeDeleteConvention(this ModelBuilder modelBuilder)
        {
            var foreignKeys = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(entity => entity.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList();
            foreach (var fk in foreignKeys)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            return modelBuilder;
        }
    }
}

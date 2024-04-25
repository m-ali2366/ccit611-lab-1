using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Backend.Service.Models
{
    public class UserAction : BaseModel
    {
        public string UserID { get; set; }
        public string Action { get; set; }
        public string Payload { get; set; }
        public virtual User User { get; set; }
    }
    public class UserActionConfiguration : IEntityTypeConfiguration<UserAction>
    {
        public void Configure(EntityTypeBuilder<UserAction> builder)
        {
            builder.ToTable("UserAction", "User");
            builder.Property(e => e.Payload).IsRequired();
            builder.HasOne(e => e.User);
                
        }
    }
}

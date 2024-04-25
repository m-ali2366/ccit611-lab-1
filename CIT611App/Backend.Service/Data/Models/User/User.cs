
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Backend.Service.Data.Models.User;
using System;

namespace Backend.Service.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }    
        public string UserName { get; set; }    
        public string Password { get; set; }
        public string SaltPassword { get; set; } = "";
        public ApplicationRoleOption Role { get; set; }
        public DateTime? LastLogin { get; set; }

        //public virtual ICollection<UserAction> UserActions { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }

    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "User");
            builder.Property(e => e.UserName).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Password).IsRequired();
            builder.Property(e => e.SaltPassword).IsRequired();
        }
    }
}

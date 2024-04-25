
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Backend.Service.Models
{
    public class Token : BaseModel
    {
        public string UserID { get; set; }

        public string Code { get; set; }

        public string IP { get; set; } = "";
        public string UserAgent { get; set; }

        public DateTime ExpirationDate { get; set; }
        public DateTime? LoggedOutDate { get; set; }
        public virtual User User { get; set; }

    }
    public class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("Token", "User");
            builder.HasOne(e => e.User).WithMany(e => e.Tokens).HasForeignKey(e => e.UserID).IsRequired();
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.IP).IsRequired();
        }
    }
}

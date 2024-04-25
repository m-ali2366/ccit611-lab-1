using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Service.Models
{
    public class OrderLog : BaseModel
    {
        public string OrderID { get; set; }
        public string Note { get; set; }
        public virtual Order Order { get; set; }    
    }
    public class OrderLogConfiguration : IEntityTypeConfiguration<OrderLog>
    {
        public void Configure(EntityTypeBuilder<OrderLog> builder)
        {
            builder.ToTable("OrderLog", "Order");
            builder.Property(p => p.Note).IsRequired();
            //builder.HasOne(e => e.Order).WithMany(e => e.OrderLogs).HasForeignKey(e => e.OrderID).IsRequired();
        }
    }
}


using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Service.Models
{
    public class BaseModel
    {
      
        public virtual string ID { get; set; } =new SequentialGuidDemo().GenerateSequentialGuid().ToString(); ///
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual string CreatedBy { get; set; } 
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        //public bool IsActive { get; set; } = false;
       // 
    }
    public  class SequentialGuidDemo
{
    public  Guid GenerateSequentialGuid()
    {
        byte[] randomBytes = Guid.NewGuid().ToByteArray();
        byte[] timestamp = BitConverter.GetBytes(DateTime.UtcNow.Ticks);
        Array.Copy(timestamp, 0, randomBytes, 0, timestamp.Length);
        return new Guid(randomBytes);
    }}


    public class BaseModelConfiguration : IEntityTypeConfiguration<BaseModel>
    {
        public void Configure(EntityTypeBuilder<BaseModel> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).IsRequired()
                .HasMaxLength(36);
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
        }
    }

}
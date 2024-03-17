using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLM.User.Domain.Entities.Models;

namespace SLM.User.Infrastructure.Persistence.FluentApiConfigurations
{
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            // Configure base entity properties
            builder.Property(b => b.CreatedAt).HasColumnName("CreatedAt").HasColumnType("datetime2").IsRequired();
            builder.Property(b => b.CreatedBy).HasColumnName("CreatedBy").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(b => b.UpdatedAt).HasColumnName("UpdatedAt").HasColumnType("datetime2");
            builder.Property(b => b.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(b => b.IsDeleted).HasColumnName("IsDeleted").HasColumnType("int").IsRequired();
        }
    }
}

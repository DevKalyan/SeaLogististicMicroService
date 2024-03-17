using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.FluentApiConfigurations
{
    public class DesignationConfiguration : IEntityTypeConfiguration<DesignationEntity>
    {
        public void Configure(EntityTypeBuilder<DesignationEntity> builder)
        {
            builder.ToTable("dbo.TblDesignation_Master");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("desingationId").HasColumnType("uniqueidentifier").IsRequired();


            builder.Property(u => u.Title).HasColumnName("title").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(u => u.Description).HasColumnName("description").HasColumnType("varchar").HasMaxLength(100).IsRequired();

            
            
        }
    }
}

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
            builder.ToTable("SLM_Master_TblDesignation");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("desingationId").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(u => u.DesignationCode).HasColumnName("designationCode").HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(u => u.DesignationName).HasColumnName("designationName").HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(u => u.DesignationDesc).HasColumnName("designationDescription").HasColumnType("varchar").HasMaxLength(100).IsRequired();

        }
    }
}

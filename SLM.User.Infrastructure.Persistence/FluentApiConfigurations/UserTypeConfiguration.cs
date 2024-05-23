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
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserTypeEntity>
    {
        public void Configure(EntityTypeBuilder<UserTypeEntity> builder)
        {
            builder.ToTable("SLM_Master_TblUserType");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("userTypeId").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(u => u.TypeName).HasColumnName("typeName").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(u => u.Description).HasColumnName("userName").HasColumnType("varchar").HasMaxLength(100).IsRequired();

        }
    }
}

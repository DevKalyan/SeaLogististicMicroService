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
    public class UserMenusConfiguration : IEntityTypeConfiguration<UserMenusEntity>
    {
        public void Configure(EntityTypeBuilder<UserMenusEntity> builder)
        {
            builder.ToTable("dbo.TblUserMenuDetail");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("userMenuId").HasColumnType("uniqueidentifier").IsRequired();


            builder.Property(u => u.UserId).HasColumnName("userId").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(u => u.AllocatedMenus).HasColumnName("allocatedMenus").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            
        }
    }
}

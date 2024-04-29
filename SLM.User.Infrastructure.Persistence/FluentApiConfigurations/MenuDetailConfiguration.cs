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
    public class MenuItemConfiguration : BaseEntityConfiguration<MenuItemsEntity>
    {
        public void Configure(EntityTypeBuilder<MenuItemsEntity> builder)
        {

            builder.ToTable("dbo.TblMenuItems_Details");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("menuItemId").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(u => u.ParentMenuCode).HasColumnName("parentMenuCd").HasColumnType("varchar").HasMaxLength(5).IsRequired();
            builder.Property(u => u.MenuItemCode).HasColumnName("menuItemCd").HasColumnType("varchar").HasMaxLength(5).IsRequired();
            builder.Property(u => u.MenuName).HasColumnName("menuTitle").HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(u => u.MenuDescription).HasColumnName("menuDescription").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(u => u.MenuUrl).HasColumnName("menuUrl").HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(u => u.MenuOrder).HasColumnName("menuItemOrder").HasColumnType("int").IsRequired();

        }
    }
}

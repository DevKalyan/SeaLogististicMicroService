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
    public class MenuConfiguration : BaseEntityConfiguration<MenuEntity>
    {
        public void Configure(EntityTypeBuilder<MenuEntity> builder)
        {
            builder.ToTable("dbo.TblMenu_Master");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("menuId").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(u => u.MenuCode).HasColumnName("menuCode").HasColumnType("varchar").HasMaxLength(5).IsRequired();
            builder.Property(u => u.MenuHeader).HasColumnName("menuTitle").HasColumnType("varchar").IsRequired().HasMaxLength(50);
            builder.Property(u => u.MenuOrder).HasColumnName("menuOrder").HasColumnType("int").IsRequired();
        }
    }
}

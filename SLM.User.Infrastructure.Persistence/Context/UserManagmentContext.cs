using Microsoft.EntityFrameworkCore;
using SLM.User.Domain.Entities.Models;
using SLM.User.Infrastructure.Persistence.FluentApiConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Context
{
    public class UserManagementContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserCredentialEntity> UserCredentials { get; set; }
        public DbSet<UserMenusEntity> UserMenus { get; set; }        
        public DbSet<UserTypeEntity> UserTypes { get; set; }

        public DbSet<DesignationEntity> Designations { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<MenuItemsEntity> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserCredentialsConfiguration());
            modelBuilder.ApplyConfiguration(new UserMenusConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DesignationConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());

            // Apply BaseEntityConfiguration last This is because the ApplyConfiguration method applies the configuration to the ModelBuilder in the order it's called and avoid overidden
            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration());
        }
    }
}

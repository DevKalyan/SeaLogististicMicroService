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
    public class UserEntityConfiguration : BaseEntityConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("dbo.TblUsersBasicDetail");
            builder.HasKey(u => u.EntityID);
            builder.Property(u=>u.EntityID).HasColumnName("UserId").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(u=>u.Firstname).HasColumnName("firstName").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(50).IsRequired();
            builder.Property(u => u.MiddleName).HasColumnName("middleName").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(50);
            builder.Property(u => u.Lastname).HasColumnName("lastName").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasColumnName("email").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(50).IsRequired();
            builder.Property(u => u.PhoneNumber).HasColumnName("phoneNumber").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(10).IsRequired();
            builder.Property(u => u.State).HasColumnName("state").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Country).HasColumnName("country").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(50).IsRequired();
            builder.Property(u => u.PostalCode).HasColumnName("postalCode").HasColumnType("varchar").HasDefaultValue(string.Empty).HasMaxLength(10).IsRequired();
            builder.Property(u => u.DateOfBirth).HasColumnName("dateOfBirth").HasColumnType("datetime2").IsRequired();

            // Relation Ships
            //builder.HasOne(ut => ut.UserType).WithMany(d => d.Users).HasForeignKey(ut => ut.UserTypeId);
            //builder.HasOne(ut => ut.Designation).WithMany(d => d.Users).HasForeignKey(ut => ut.DesignationId);

            builder.HasOne(uc => uc.UserCredential).WithOne().HasForeignKey<UserCredentialEntity>(uc => uc.UserId);

            builder.HasOne(uc => uc.UserMenu).WithOne().HasForeignKey<UserMenusEntity>(uc => uc.UserId);

            builder.HasOne(u => u.Designation).WithMany(d => d.Users).HasForeignKey(u => u.DesignationId);

            builder.HasOne(u => u.UserType).WithMany(d => d.Users).HasForeignKey(u => u.UserTypeId);


        }
    }
}

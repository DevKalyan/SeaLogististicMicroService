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
    public class UserCredentialsConfiguration : BaseEntityConfiguration<UserCredentialEntity>
    {
        public  void Configure(EntityTypeBuilder<UserCredentialEntity> builder)
        {

            builder.ToTable("dbo.TblUserCredentialDetail");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("userCredentialId").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(u => u.UserId).HasColumnName("userId").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(u => u.Username).HasColumnName("userName").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(u => u.HashedPassword).HasColumnName("passsword").HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(u => u.DtPasswordChanged).HasColumnName("passwordChangedDt").HasColumnType("datetime2");      
        }
    }
}

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
    public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplatesEntity>
    {
        public  void Configure(EntityTypeBuilder<EmailTemplatesEntity> builder)
        {
            builder.ToTable("SLM_Master_TblEmailTemplate");
            builder.HasKey(u => u.EntityID);
            builder.Property(u => u.EntityID).HasColumnName("emailTemplateId").HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(u => u.EmailTemplateCode).HasColumnName("emailTemplateCode").HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Property(u => u.EmailTemplateName).HasColumnName("emailTemplateName").HasColumnType("varchar").IsRequired().HasMaxLength(50);
            builder.Property(u => u.EmailTemplateDesc).HasColumnName("emailTemplateDesc").HasColumnType("varchar").IsRequired().HasMaxLength(100);
            builder.Property(u => u.EmailTemplate).HasColumnName("emailTemplate").HasColumnType("varchar").IsRequired().HasMaxLength(1000);
        }
    }
}

using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Interfaces
{
    public interface IEmailTemplateRepository
    {
        Task<EmailTemplatesEntity> GetEmailTemplateDetailsForEmailTemplateIdAsync(Guid EmailTemplateid);

        Task<EmailTemplatesEntity> GetEmailTemplateDetailsForEmailTemplateByCodeAsync(string emailTemplateCode);
        Task<List<EmailTemplatesEntity>> GetAllEmailTemplatesAsync();
        Task AddNewEmailTemplateAsync(EmailTemplatesEntity EmailTemplate);
        Task UpdateExistingEmailTemplateAsync(EmailTemplatesEntity EmailTemplate);
        Task DeleteEmailTemplateAsync(Guid EmailTemplateid);
    }
}

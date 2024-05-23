using SLM.User.Application.Utilities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Interfaces
{
    public interface IEmailTempateService
    {
        Task<List<EmailTemplateViewModel>> GetAllEmailTemplateAsync();
        Task InsertEmailTemplate(EmailTemplateViewModel emailTemplateDetails);
        Task UpdateExistingEmailTemplate(EmailTemplateViewModel emailTemplateDetails);
        Task DeleteExistingEmailTemplate(Guid emailTemplateId);
    }
}

using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.Mappers
{
    public class EmailTemplateMapper
    {
        public static List<EmailTemplateViewModel> ConvertEmailTemplatenEntityToEmailTemplatenViewModel(List<EmailTemplatesEntity> emailTemplatenentity)
        {
            List<EmailTemplateViewModel> listEmailTemplates = new List<EmailTemplateViewModel>();

            foreach (var item in emailTemplatenentity)
            {
                EmailTemplateViewModel emailTemplateViewModel = new EmailTemplateViewModel();

                emailTemplateViewModel.TemplateCode = item.EmailTemplateCode;
                emailTemplateViewModel.TemplateName = item.EmailTemplateName;
                emailTemplateViewModel.TemplateDescription = item.EmailTemplateDesc;
                emailTemplateViewModel.CreatedAt = item.CreatedAt;
                emailTemplateViewModel.CreatedBy = item.CreatedBy;
                emailTemplateViewModel.UpdatedAt = item.UpdatedAt;
                emailTemplateViewModel.UpdatedBy = item.UpdatedBy;
                emailTemplateViewModel.UpdatedAt = item.UpdatedAt;
                listEmailTemplates.Add(emailTemplateViewModel);
            }
            return listEmailTemplates;
        }
        public static EmailTemplateViewModel ConvertDesignationEntityToEmailTemplateViewModel(EmailTemplatesEntity emailTemplateEntity)
        {
            EmailTemplateViewModel _emailTemplateViewModel = new()
            {
                TemplateCode = emailTemplateEntity.EmailTemplateCode,
                TemplateName = emailTemplateEntity.EmailTemplateName,
                TemplateDescription = emailTemplateEntity.EmailTemplateDesc,
                CreatedAt = emailTemplateEntity.CreatedAt,
                CreatedBy = emailTemplateEntity.CreatedBy,
                UpdatedAt = emailTemplateEntity.UpdatedAt,
                UpdatedBy = emailTemplateEntity.UpdatedBy                
            };           

            return _emailTemplateViewModel;
        }
        public static EmailTemplatesEntity ConvertEmailTemplateViewModelToEmailTemplateEntity(EmailTemplateViewModel emailTemplateViewModel)
        {
            EmailTemplatesEntity _emailTemplateEntity = new()
            {
                EmailTemplateCode = emailTemplateViewModel.TemplateCode,
                EmailTemplateName = emailTemplateViewModel.TemplateName,
                EntityID = emailTemplateViewModel.PrimaryId,
                EmailTemplateDesc= emailTemplateViewModel.TemplateDescription,
                EmailTemplate= emailTemplateViewModel.Template,
                CreatedAt = emailTemplateViewModel.CreatedAt,
                UpdatedAt = emailTemplateViewModel.UpdatedAt,
                UpdatedBy = emailTemplateViewModel.UpdatedBy,
                CreatedBy = emailTemplateViewModel.CreatedBy
            };

            return _emailTemplateEntity;
        }
    }
}

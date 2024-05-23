using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.Mappers;
using SLM.User.Application.Utilities.ViewModel;
using SLM.User.Domain.Interfaces;

namespace SLM.User.Application.Services
{
    public class EmailTemplateService : IEmailTempateService
    {
        private readonly IEmailTemplateRepository _repo;
        public EmailTemplateService(IEmailTemplateRepository emailTemplateRepo)
        {
            _repo = emailTemplateRepo;
        }

        public async Task DeleteExistingEmailTemplate(Guid emailTemplateId)
        {
            await _repo.DeleteEmailTemplateAsync(emailTemplateId);
        }

        public async Task<List<EmailTemplateViewModel>> GetAllEmailTemplateAsync()
        {
            var _emailTemplateList = await _repo.GetAllEmailTemplatesAsync();
            return EmailTemplateMapper.ConvertEmailTemplatenEntityToEmailTemplatenViewModel(_emailTemplateList);
        }

        public Task InsertEmailTemplate(EmailTemplateViewModel emailTemplateDetails)
        {
            var _emailTemplateEntity = EmailTemplateMapper.ConvertEmailTemplateViewModelToEmailTemplateEntity(emailTemplateDetails);
            return _repo.AddNewEmailTemplateAsync(_emailTemplateEntity);
        }

        public async Task UpdateExistingEmailTemplate(EmailTemplateViewModel emailTemplateDetails)
        {
            var emailTemp = EmailTemplateMapper.ConvertEmailTemplateViewModelToEmailTemplateEntity(emailTemplateDetails);
            await _repo.UpdateExistingEmailTemplateAsync(emailTemp);

        }
    }
}

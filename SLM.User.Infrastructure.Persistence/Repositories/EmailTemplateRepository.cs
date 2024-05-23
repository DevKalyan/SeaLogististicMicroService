using Microsoft.EntityFrameworkCore;
using SLM.User.Domain.Entities.Models;
using SLM.User.Domain.Interfaces;
using SLM.User.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.Repositories
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private readonly UserManagementContext _localuserManagmentContext;
        public EmailTemplateRepository(UserManagementContext context)
        {
            _localuserManagmentContext = context;
        }

        public async Task AddNewEmailTemplateAsync(EmailTemplatesEntity emailtemplate)
        {
            await _localuserManagmentContext.EmailTemplates.AddAsync(emailtemplate);
            _ = _localuserManagmentContext.SaveChanges();
        }

        public async Task DeleteEmailTemplateAsync(Guid EmailTemplateid)
        {
            var result = await _localuserManagmentContext.EmailTemplates.FirstOrDefaultAsync(e => e.EntityID == EmailTemplateid);
            if (result != null)
            {
                //_localuserManagmentContext.Designations.Remove(result);
                result.IsDeleted = 1;
                _localuserManagmentContext.SaveChanges();
            }
        }

        public async Task<List<EmailTemplatesEntity>> GetAllEmailTemplatesAsync()
        {
            var result = await _localuserManagmentContext.EmailTemplates.ToListAsync();
            return result;
        }

        public async Task<EmailTemplatesEntity> GetEmailTemplateDetailsForEmailTemplateByCodeAsync(string emailTemplateCode)
        {
            var result = await _localuserManagmentContext.EmailTemplates.FirstOrDefaultAsync(e => e.EmailTemplateCode == emailTemplateCode);
            return result;
        }

        public async Task<EmailTemplatesEntity> GetEmailTemplateDetailsForEmailTemplateIdAsync(Guid EmailTemplateid)
        {
            var result = await _localuserManagmentContext.EmailTemplates.FirstOrDefaultAsync(e => e.EntityID == EmailTemplateid);
            return result;
        }

        public async Task UpdateExistingEmailTemplateAsync(EmailTemplatesEntity EmailTemplate)
        {
            _localuserManagmentContext.Entry(EmailTemplate).State= EntityState.Modified;
            await _localuserManagmentContext.SaveChangesAsync();

        }
    }
}

 
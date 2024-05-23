using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.ViewModel;

namespace SLM.User.Service.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmailTemplateController : ControllerBase
    {
        private readonly ILogger<EmailTemplateController> _logger;
        private readonly IEmailTempateService _emailTemplateService;
        public EmailTemplateController(ILogger<EmailTemplateController> logger, IEmailTempateService emailTemplateService)
        {
            _logger = logger;
            _emailTemplateService = emailTemplateService;
        }
        [HttpGet]
        [Route("LoadAllEmailTemplates")]
        public async Task<IActionResult> GetAllDesignations()
        {
            try
            {
                var designtionList = await _emailTemplateService.GetAllEmailTemplateAsync();
                if (designtionList == null)
                {
                    return NotFound();
                }
                return Ok(designtionList);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpPost]
        [Route("InsertNewEmailTemplate")]
        public async Task<IActionResult> NewEmailTemplate(EmailTemplateViewModel emailTemplate)
        {
            try
            {
                await _emailTemplateService.InsertEmailTemplate(emailTemplate);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpPut]
        [Route("UpdateExistingEmailTemplate")]
        public async Task<IActionResult> UpdateDesignationDetils(EmailTemplateViewModel emailTemplate)
        {
            try
            {
                await _emailTemplateService.UpdateExistingEmailTemplate(emailTemplate);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpDelete]
        [Route("DeleteExistingEmailTemplate")]
        public async Task<IActionResult> DeleteDesignationDetils(Guid emailTemplateId)
        {
            try
            {
                await _emailTemplateService.DeleteExistingEmailTemplate(emailTemplateId);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}

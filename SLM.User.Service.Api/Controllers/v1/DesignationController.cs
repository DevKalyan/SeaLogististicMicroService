using Microsoft.AspNetCore.Mvc;
using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.ViewModel;

namespace SLM.User.Service.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly ILogger<DesignationController> _logger;
        private readonly IDesignationService _designationService;
        public DesignationController(ILogger<DesignationController> logger, IDesignationService designationService)
        {
            _logger = logger;
            _designationService = designationService;
        }
        [HttpGet]
        [Route("LoadAllDesignations")]
        public async Task<IActionResult> GetAllDesignations()
        {
            try
            {
                var designtionList = await _designationService.GetDesignationsAsync();
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
        [Route("InsertNewDesignationDetails")]
        public async Task<IActionResult> NewDesigation(DesignationViewModel designation)
        {
            try
            {
                await _designationService.InsertNewDesignation(designation);                
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpPut]
        [Route("UpdateExistingDesignationDetils")]
        public async Task<IActionResult> UpdateDesignationDetils(DesignationViewModel designation)
        {
            try
            {
                await _designationService.UpdateExistingDesignation(designation);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpDelete]
        [Route("DeleteExistingDesignationDetils")]
        public async Task<IActionResult> DeleteDesignationDetils(Guid designationId)
        {
            try
            {
                await _designationService.DeleteExistingDesignation(designationId);
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLM.User.Application.Interfaces;

namespace SLM.User.Service.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly ILogger<UserTypeController> _logger;
        private readonly IUserTypeService _userTypeService;
        public UserTypeController(ILogger<UserTypeController> logger, IUserTypeService userTypeService)
        {
            _logger = logger;
            _userTypeService = userTypeService;
        }
        [HttpGet]
        [Route("LoadAllUserTypes")]
        public async Task<IActionResult>GetAllUserTypes()
        {
            try
            {
                var userTypeList = await _userTypeService.GetAllUserTypes();
                if (userTypeList == null)
                {
                    return NotFound();
                }
                return Ok(userTypeList);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLM.User.Application.Interfaces;
using SLM.User.Application.Utilities.ViewModel;

namespace SLM.User.Service.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> ValidateUser(string username, string password)
        {
            try
            {
                var user = await _userService.ValidateUser(username, password);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult>InsertNewEmpoloyee(UserViewModel newUserDetails)
        {
            try
            {
                await _userService.InsertNewUserDetails(newUserDetails);                
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

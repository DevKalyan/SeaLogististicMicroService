using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLM.User.Application.Interfaces;

namespace SLM.User.Service.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuService _menuService;

        public MenuController(ILogger<MenuController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMenus()
        {
            try
            {
                var menus = await _menuService.GetAllMenuAsync();
                if (menus == null || menus.Count()==0)
                {
                    return NotFound();
                }
                return Ok(menus);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
    }
}

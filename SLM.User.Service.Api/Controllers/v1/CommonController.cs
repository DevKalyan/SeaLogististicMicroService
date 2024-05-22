using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLM.User.Application.Interfaces;

namespace SLM.User.Service.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonService _commonService;

        public CommonController(ILogger<CommonController> logger, ICommonService commonService)
        {
            _logger = logger;
            _commonService = commonService;
        }
        [HttpGet]        
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _commonService.GetCountryListAsync();
                if (countries == null || countries.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(countries.Take(10));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }
        
    }
}

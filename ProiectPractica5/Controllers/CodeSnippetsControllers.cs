using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using System.Text.Json;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeSnippetsControllers : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public CodeSnippetsControllers(ILogger<WeatherForecastController> logger, ClubMembershipDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200,_context.CodeShippets);
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            return StatusCode(200);
        }

        [HttpPut]
        public IActionResult Put()
        {
            return StatusCode(200);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return StatusCode(200);
        }
    }
}

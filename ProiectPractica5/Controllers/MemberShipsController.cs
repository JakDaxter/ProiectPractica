using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberShipsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public MemberShipsController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200);
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

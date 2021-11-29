using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersShipTypesController : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public MembersShipTypesController(ILogger<WeatherForecastController> logger, ClubMembershipDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _context.MemberShipTypes);
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

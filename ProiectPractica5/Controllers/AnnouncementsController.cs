using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public AnnouncementsController(ILogger<WeatherForecastController> logger)
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class AnnouncementsController : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public AnnouncementsController(ILogger<WeatherForecastController> logger, ClubMembershipDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _context.Announcements);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Announcements announcements)
        {
            try
            {
                using (var context = _context)
                {
                    var codeS = new Announcements()
                    {
                        IdAnnouncement = Guid.NewGuid(),//nu il trimitem in swagger
                        ValidFrom = announcements.ValidFrom,
                        ValidTo = announcements.ValidTo,
                        Title = announcements.Title,
                        Text = announcements.Text,
                        EventDateTime = announcements.EventDateTime,
                        Tags = announcements.Tags
                    };
                    context.Entry(codeS).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    context.SaveChanges();
                    return StatusCode(200, "Code announcements was added in database");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody] Announcements announcements)
        {
            try
            {
                using (var context = _context)
                {
                    context.Update(announcements);
                    context.SaveChanges();
                }
                return StatusCode(200, "Code announcements was modify in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Announcements announcements)
        {
            try
            {
                using (var context = _context)
                {
                    context.Remove(announcements);
                    context.SaveChanges();
                }
                return StatusCode(200, "Code announcements was delete in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

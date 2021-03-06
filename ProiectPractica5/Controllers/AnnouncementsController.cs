using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System;
using System.Linq;
using System.Net;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsServices _announcementsServices;
        private readonly ILogger<AnnouncementsController> _logger;
        public AnnouncementsController(ILogger<AnnouncementsController> logger, IAnnouncementsServices announcementsServices)
        {
            _announcementsServices = announcementsServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DbSet<Announcements> codeSnippets = _announcementsServices.Get();
            if (codeSnippets != null)
            {
                if (codeSnippets.ToList().Count > 0) 
                {
                    return StatusCode(200, _announcementsServices.Get());
                }
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Announcements announcements)
        {
            try
            {
                if (announcements != null)
                {
                    _announcementsServices.Post(announcements);
                    return StatusCode(201, Constants.CreateAnnouncementsMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);

        }

        [HttpPut]
        public IActionResult Put([FromBody] Announcements announcements)
        {
            try
            {
                if (announcements != null)
                {
                    _announcementsServices.Put(announcements);
                    return StatusCode(202, Constants.UpdateAnnouncementsMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Announcements announcements)
        {
            try
            {
                if (announcements != null)
                {
                    _announcementsServices.Delete(announcements);
                    return StatusCode(200, Constants.DeleteAnnouncementsMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);
        }
    }
}

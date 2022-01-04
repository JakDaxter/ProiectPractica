using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
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
            if (_announcementsServices != null)
            {
                return StatusCode(200, _announcementsServices.Get());
            }
            return StatusCode(404, "No codeSnippetsFound");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Announcements announcements)
        {
            try
            {
                _announcementsServices.Post(announcements);
                return StatusCode(200, "Announcements was added in database");

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
                _announcementsServices.Put(announcements);
                return StatusCode(200, "Announcemets was modify in database");
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
                _announcementsServices.Delete(announcements);
                return StatusCode(200, "Code snippet was delete in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

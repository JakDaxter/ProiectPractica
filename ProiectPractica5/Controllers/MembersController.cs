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
    public class MembersController : ControllerBase
    {
        private readonly IMembersServices _membersServices;
        private readonly ILogger<MembersController> _logger;
        public MembersController(ILogger<MembersController> logger, IMembersServices memberServices)
        {
            _membersServices = memberServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DbSet<Members> members = _membersServices.Get();
            if (members != null)
            {
                if (members.ToList().Count > 0) 
                {
                    return StatusCode(200, _membersServices.Get());
                }
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Members members)
        {
            try
            {
                if (members != null)
                {
                    _membersServices.Post(members);
                    return StatusCode(201, Constants.CreateMembersMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);

        }

        [HttpPut]
        public IActionResult Put([FromBody] Members members)
        {
            try
            {
                if (members != null)
                {
                    _membersServices.Put(members);
                    return StatusCode(202, Constants.UpdateMembersMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Members members)
        {
            try
            {
                if (members != null)
                {
                    _membersServices.Delete(members);
                    return StatusCode(200, Constants.DeleteMembersMessage);
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

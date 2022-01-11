using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class MembersController : ControllerBase
    {
        private readonly IMembersServices _membersServices;
        private readonly ILogger<CodeSnippetsController> _logger;
        public MembersController(ILogger<CodeSnippetsController> logger, IMembersServices memberServices)
        {
            _membersServices = memberServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_membersServices != null)
            {
                return StatusCode(200, _membersServices.Get());
            }
            return StatusCode(404, "No Members Found");
        }

        [HttpPost]
        public IActionResult Post([FromBody] Members members)
        {
            try
            {
                _membersServices.Post(members);
                return StatusCode(200, "Member was added in database");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody] Members members)
        {
            try
            {
               _membersServices.Put(members);
                return StatusCode(200, "Member was modify in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Members members)
        {
            try
            {
                _membersServices.Delete(members);
                return StatusCode(200, "Member was delete in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

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
    public class MemberShipTypesController : ControllerBase
    {
        private readonly IMemberShipTypesServices _memberShipTypesServices;
        private readonly ILogger<CodeSnippetsController> _logger;
        public MemberShipTypesController(ILogger<CodeSnippetsController> logger, IMemberShipTypesServices memberShipTypesServices)
        {
            _memberShipTypesServices = memberShipTypesServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_memberShipTypesServices != null)
            {
                return StatusCode(200, _memberShipTypesServices.Get());
            }
            return StatusCode(404, "No MemberShipType Found");
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                _memberShipTypesServices.Post(memberShipTypes);
                return StatusCode(200, "MemberShipType was added in database");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                _memberShipTypesServices.Put(memberShipTypes);
                return StatusCode(200, "MemberShipType was modify in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                _memberShipTypesServices.Delete(memberShipTypes);
                return StatusCode(200, "MemberShipType was delete in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

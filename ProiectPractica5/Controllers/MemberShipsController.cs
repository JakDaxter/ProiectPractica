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
    public class MemberShipsController : ControllerBase
    {
        private readonly IMemberShipsServices _memberShipsServices;
        private readonly ILogger<CodeSnippetsController> _logger;
        public MemberShipsController(ILogger<CodeSnippetsController> logger, IMemberShipsServices memberShipsServices)
        {
            _memberShipsServices = memberShipsServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (_memberShipsServices != null)
            {
                return StatusCode(200, _memberShipsServices.Get());
            }
            return StatusCode(404, "No MemberShip Found");
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberShips memberShips)
        {
            try
            {
                _memberShipsServices.Post(memberShips);
                return StatusCode(200, "MemberShip was added in database");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody] MemberShips memberShips)
        {
            try
            {
                _memberShipsServices.Put(memberShips);
                return StatusCode(200, "MemberShip was modify in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] MemberShips memberShips)
        {
            try
            {
                _memberShipsServices.Delete(memberShips);
                return StatusCode(200, "MemberShip was delete in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

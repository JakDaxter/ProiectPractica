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
    public class MemberShipsController : ControllerBase
    {
        private readonly IMemberShipsServices _memberShipsServices;
        private readonly ILogger<MemberShipsController> _logger;
        public MemberShipsController(ILogger<MemberShipsController> logger, IMemberShipsServices memberShipsServices)
        {
            _memberShipsServices = memberShipsServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DbSet<MemberShips> memberShips = _memberShipsServices.Get();
            if (memberShips != null)
            {
                if (memberShips.ToList().Count > 0)
                {
                    return StatusCode(200, _memberShipsServices.Get());
                }
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberShips memberShips)
        {
            try
            {
                if (memberShips != null)
                {
                    _memberShipsServices.Post(memberShips);
                    return StatusCode(201, Constants.CreateMemberShipsMessage);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);

        }

        [HttpPut]
        public IActionResult Put([FromBody] MemberShips memberShips)
        {
            try
            {
                if (memberShips != null)
                {
                    _memberShipsServices.Put(memberShips);
                    return StatusCode(202, Constants.UpdateMemberShipsMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] MemberShips memberShips)
        {
            try
            {
                if (memberShips != null)
                {
                    _memberShipsServices.Delete(memberShips);
                    return StatusCode(200, Constants.DeleteMemberShipsMessage);
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

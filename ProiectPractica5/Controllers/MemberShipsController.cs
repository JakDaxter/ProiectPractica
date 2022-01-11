using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System;
using System.Linq;

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
                    return StatusCode(201, _memberShipsServices.Get());
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
                    return StatusCode(201, "MemberShip was added in database");
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
                    return StatusCode(201, "MemberShip was modify in database");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] MemberShips memberShips)
        {
            try
            {
                if (memberShips != null)
                {
                    _memberShipsServices.Delete(memberShips);
                    return StatusCode(201, "MemberShip was delete in database");
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

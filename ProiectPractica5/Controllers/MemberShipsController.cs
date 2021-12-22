using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class MemberShipsController : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public MemberShipsController(ILogger<WeatherForecastController> logger, ClubMembershipDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _context.MemberShips);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberShips memberShips)
        {
            try
            {
                using (var context = _context)
                {
                    var codeS = new MemberShips()
                    {
                        IdMembership = Guid.NewGuid(),//nu il trimitem in swagger
                        IdMember = memberShips.IdMember,
                        IdMembershipType = memberShips.IdMembershipType,
                        StartData = memberShips.StartData,
                        EndData = memberShips.EndData,
                        Lvl = memberShips.Lvl//nu il timitem in swagger
                    };
                    context.Entry(codeS).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                    context.SaveChanges();
                    return StatusCode(200, "Code snippet was added in database");
                }
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
                using (var context = _context)
                {
                    context.Update(memberShips);
                    context.SaveChanges();
                }
                return StatusCode(200, "Code snippet was modify in database");
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
                using (var context = _context)
                {
                    context.Remove(memberShips);
                    context.SaveChanges();
                }
                return StatusCode(200, "Code snippet was delete in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

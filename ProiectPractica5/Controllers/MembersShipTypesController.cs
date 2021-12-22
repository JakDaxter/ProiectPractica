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
    public class MembersShipTypesController : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public MembersShipTypesController(ILogger<WeatherForecastController> logger, ClubMembershipDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _context.MemberShipTypes);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                using (var context = _context)
                {
                    var codeS = new MemberShipTypes()
                    {
                        IdMembershipType = Guid.NewGuid(),//nu il trimitem in swagger
                        Name = memberShipTypes.Name,
                        Description = memberShipTypes.Description,
                        SuscriptionLengthInMounths = memberShipTypes.SuscriptionLengthInMounths
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
        public IActionResult Put([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                using (var context = _context)
                {
                    context.Update(memberShipTypes);
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
        public IActionResult Delete([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                using (var context = _context)
                {
                    context.Remove(memberShipTypes);
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

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
    public class MembersController : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<MembersController> _logger;
        public MembersController(ILogger<MembersController> logger, ClubMembershipDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _context.Members);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Members members)
        {
            try
            {
                using (var context = _context)
                {
                    var codeS = new Members()
                    {
                        IdMembers = Guid.NewGuid(),//nu il trimitem in swagger
                        Name = members.Name,
                        Title = members.Title,
                        Position = members.Position,
                        Description = members.Description,
                        Resume = members.Resume//nu il timitem in swagger
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
        public IActionResult Put([FromBody] Members members)
        {
            try
            {
                using (var context = _context)
                {
                    context.Update(members);
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
        public IActionResult Delete([FromBody] Members members)
        {
            try
            {
                using (var context = _context)
                {
                    context.Remove(members);
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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;
using System.Text.Json;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CodeSnippetsControllers : ControllerBase
    {
        private readonly ClubMembershipDbContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        public CodeSnippetsControllers(ILogger<WeatherForecastController> logger, ClubMembershipDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200,_context.CodeShippets);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CodeShippets codeShippets)
        {
            try
            {
                using (var context = _context)
                {
                    var codeS = new CodeShippets()
                    {
                        IdCodeShippet = Guid.NewGuid(),//nu il trimitem in swagger
                        Title = codeShippets.Title,
                        ContentCode = codeShippets.ContentCode,
                        IdMember = codeShippets.IdMember,
                        IsPublished = codeShippets.IsPublished,
                        DatetimeAdded = DateTime.Now//nu il timitem in swagger
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
        public IActionResult Put([FromBody] CodeShippets codeShippets)
        {
            try
            {
                using (var context = _context)
                {
                    context.Update(codeShippets);
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
        public IActionResult Delete([FromBody] CodeShippets codeShippets)
        {
            try
            {
                using (var context = _context)
                {
                    context.Remove(codeShippets);
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

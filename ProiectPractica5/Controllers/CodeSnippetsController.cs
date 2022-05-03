using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CodeSnippetsController : ControllerBase
    {
        private readonly ICodeSnippetsServices _codeSnippetsServices;
        private readonly ILogger<CodeSnippetsController> _logger;
        public CodeSnippetsController(ILogger<CodeSnippetsController> logger, ICodeSnippetsServices codeSnippetsServices)
        {
            _codeSnippetsServices = codeSnippetsServices;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            DbSet<CodeSnippets> codeSnippets = await _codeSnippetsServices.Get();
            if (codeSnippets != null)
            {
                if (codeSnippets.ToList().Count > 0) 
                {
                    return StatusCode(200,await _codeSnippetsServices.Get());
                }
            }
            return StatusCode(404);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CodeSnippets codeShippets)
        {
            try
            {
                if(codeShippets != null)
                {
                    await _codeSnippetsServices.Post(codeShippets);
                    return StatusCode(201, Constants.CreateCodeSnippetMessage);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);
            
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CodeSnippets codeShippets)
        {
            try
            {
                if (codeShippets != null)
                {
                    await _codeSnippetsServices.Put(codeShippets);
                    return StatusCode(202, Constants.UpdateCodeSnippetMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex);
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] CodeSnippets codeShippets)
        {
            try
            {
                if (codeShippets != null)
                {
                    await _codeSnippetsServices.Delete(codeShippets);
                    return StatusCode(200, Constants.DeleteCodeSnippetMessage);
                }
            }
            catch (Exception ex) { return StatusCode(500, ex); }
            return StatusCode(500);
        }
    }
}

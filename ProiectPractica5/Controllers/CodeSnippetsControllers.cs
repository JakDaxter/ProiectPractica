using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System;
using System.Text.Json;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CodeSnippetsControllers : ControllerBase
    {
        private readonly ICodeSnippetsServices _codeSnippetsServices;
        private readonly ILogger<CodeSnippetsControllers> _logger;
        public CodeSnippetsControllers(ILogger<CodeSnippetsControllers> logger, ICodeSnippetsServices codeSnippetsServices)
        {
            _codeSnippetsServices = codeSnippetsServices;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            if (_codeSnippetsServices != null)
            {
                return StatusCode(200, _codeSnippetsServices.Get()) ;
            }
            return StatusCode(404,"No codeSnippets Found");
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CodeShippets codeShippets)
        {
            try
            {
                _codeSnippetsServices.Post(codeShippets);
                return StatusCode(200, "CodeSnippet was added in database");
                
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
                _codeSnippetsServices.Put(codeShippets);
                return StatusCode(200, "CodeSnippet was modify in database");
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
                _codeSnippetsServices.Delete(codeShippets);
                return StatusCode(200, "CodeSnippet was delete in database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}

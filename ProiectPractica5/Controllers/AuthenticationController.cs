using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectPractica5.Models.Authentication;
using ProiectPractica5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private IUserServices _userService;
        public AuthenticationController(IUserServices userService)
        {
            _userService = userService;
        }



        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);



            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });



            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProiectPractica5.Models;
using ProiectPractica5.Services;
using System;
using System.Linq;

namespace ProiectPractica5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class MemberShipTypesController : ControllerBase
    {
        private readonly IMemberShipTypesServices _memberShipTypesServices;
        private readonly ILogger<MemberShipTypesController> _logger;
        public MemberShipTypesController(ILogger<MemberShipTypesController> logger, IMemberShipTypesServices memberShipTypesServices)
        {
            _memberShipTypesServices = memberShipTypesServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DbSet<MemberShipTypes> memberShipTypes = _memberShipTypesServices.Get();
            if (memberShipTypes != null)
            {
                if (memberShipTypes.ToList().Count > 0) 
                {
                    return StatusCode(200, _memberShipTypesServices.Get());
                }
            }
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                if (memberShipTypes != null)
                {
                    _memberShipTypesServices.Post(memberShipTypes);
                    return StatusCode(201, Constants.CreateMemberShipTypesMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);

        }

        [HttpPut]
        public IActionResult Put([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                if (memberShipTypes != null)
                {
                    _memberShipTypesServices.Put(memberShipTypes);
                    return StatusCode(202, Constants.UpdateMemberShipTypesMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return StatusCode(500);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] MemberShipTypes memberShipTypes)
        {
            try
            {
                if (memberShipTypes != null)
                {
                    _memberShipTypesServices.Delete(memberShipTypes);
                    return StatusCode(200, Constants.DeleteMemberShipTypesMessage);
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

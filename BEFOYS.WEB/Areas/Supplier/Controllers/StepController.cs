using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BEFOYS.WEB.Areas.Supplier.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StepController : ControllerBase
    {
        
        //[HttpPost]
        //public IActionResult HaghighiStep1([FromBody]View)
        //{
        //    return Ok();
        //}
        //[HttpPost]
        //public IActionResult HaghighiStep1([FromBody]View)
        //{
        //    return Ok();
        //}
    }
}
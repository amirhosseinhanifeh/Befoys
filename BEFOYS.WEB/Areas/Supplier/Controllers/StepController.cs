using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Register.Haghighi;
using BEFOYS.DataLayer.ViewModels.Register.Step;
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
        private ServiceContext _context;

        public StepController(ServiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Step1([FromBody]ViewStep1 model)
        {
            var user = _context.Tbl_Login.Find(User.Identity.UserID());
            //if(user.GetType=="haghighi")
            //{
            //    //do somthing
            //}
            //else
            //{
            //    //do somthing
            //}
            return Ok();
        }
        [HttpPost]
        public IActionResult Step2([FromBody]ViewStep2 model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Step3([FromBody]ViewStep3 model)
      
        { 
            return Ok();
        }
        [HttpPost]
        public IActionResult Step4()
        {
            return Ok();
        }
    }
}
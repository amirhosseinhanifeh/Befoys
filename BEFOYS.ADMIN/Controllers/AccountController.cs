using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace BEFOYS.ADMIN.Controllers
{
    public class AccountController : Controller
    {
        private readonly ServiceContext _context;

        public AccountController(ServiceContext context)
        {
            _context = context;
        }

        public IActionResult Auth(string token)
        {
            if (token == null)
            {
                return BadRequest();
            }
            return RedirectToAction("");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(TblLogin model)
        {
            //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            //identity.AddClaim(new Claim(ClaimTypes.Name, user.Ssn));
            //identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));
            //identity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));

            //foreach (var role in user.Roles)
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, role.Role));
            //}

            //var principal = new ClaimsPrincipal(identity);
            //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return View();
        }
    }
}
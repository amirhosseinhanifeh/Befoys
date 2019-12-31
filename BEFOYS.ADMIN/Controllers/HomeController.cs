using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BEFOYS.ADMIN.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BEFOYS.Common.AppUser;

namespace BEFOYS.ADMIN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Authorize]
        public IActionResult Index()
        {
            //var test = User.Identity.UserID();
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //if (identity != null)
            //{
            //    IEnumerable<Claim> claims = identity.Claims;
            //    // or
            //    //string test = identity.FindFirst("ClaimName").Value;

            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

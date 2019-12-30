using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BEFOYS.ADMIN.Areas.Setting.Controllers
{
    public class HomeController : Controller
    {
        [Area("Setting")]
        [Route("Setting/[controller]/[action]/{id?}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
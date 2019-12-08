using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Panel.Controllers
{
    public class OrganizationTypeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
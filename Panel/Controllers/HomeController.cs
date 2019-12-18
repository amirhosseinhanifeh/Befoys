using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Panel.Classes;
using Panel.DownloadData;
using Panel.Models;

namespace Panel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SetType(Enum_UserType type)
        {
            string Token = Get("token");
            string json = JsonConvert.SerializeObject(new {type=type });
            var result = DownloadData<dynamic>.DownloadValue($"{ServerUrl.ServerAddress}/api/Step/SetOrganizationType?type={type}", "POST", json, Token);
            switch(type)
            {
                case Enum_UserType.Supplier_Real:
                    return RedirectToAction("Step1", "Haghighi");
                    break;
                case Enum_UserType.Supplier_Legal:
                    return RedirectToAction("Step1", "Hoghoghi");
                    break;
                    
            }
            return View();
        }
        public string Get(string key)
        {
            return Request.Cookies[key];
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Panel.DownloadData;
using Panel.ViewModels.Account;

namespace Panel.Controllers
{
    public class HoghoghiController : Controller
    {
        public IActionResult Step1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Step1(HoghoghiViewModel model)
        {
            model.type = BEFOYS.DataLayer.Enums.Enum_UserType.Supplier_Legal;
            string Token = Get("token");
            model.StepNumber = 1;
            string json = JsonConvert.SerializeObject(model);
            var result = DownloadData<dynamic>.DownloadValue("https://localhost:44317/api/Step/UpdateInformation", "POST", json, Token);
            return View();
        }
        
        public string Get(string key)
        {
            return Request.Cookies[key];
        }
    }
}
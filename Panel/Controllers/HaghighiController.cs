using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Panel.DownloadData;
using Panel.ViewModels.Account;

namespace Panel.Controllers
{
    public class HaghighiController : Controller
    {
        public IActionResult Step1()
        {
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Step1([FromBody]HaghighiViewModel model)
        {
            model.type = BEFOYS.DataLayer.Enums.Enum_UserType.Supplier_Real;
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
        [Route("Step/Step2")]
        public IActionResult Step2()
        {
            return View();
        }
        [HttpPost]
       
        public IActionResult Step2(StepValuesViewModel[] model)
        {

            string Token = Get("token");
            //model.StepNumber = 1;
            string json = JsonConvert.SerializeObject(model);
            var result = DownloadData<dynamic>.DownloadValue("https://localhost:44317/api/Step/UpdateInformation", "POST", json, Token);
            return View();
        }
        [Route("Step/Step3")]
        public IActionResult Step3()
        {
            return View();
        }
        
        public IActionResult Step4()
        {
            return View();
        }
    }
}
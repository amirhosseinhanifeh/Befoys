using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Enums;
using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        public IActionResult Step1(HaghighiViewModel model)
        {
            model.type = BEFOYS.DataLayer.Enums.Enum_UserType.Supplier_Real;
            string Token = Get("token");
            model.StepNumber = 1;
            string json = JsonConvert.SerializeObject(model);
            var result = DownloadData<dynamic>.DownloadValue("https://localhost:44317/api/Step/UpdateInformation", "POST", json, Token);
            return View();
        }

        public IActionResult Result()
        {
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
        public IActionResult Step2(StepValuesViewModel[] infoes)
        {
            string Token = Get("token");
            //model.StepNumber = 1;
            string json = JsonConvert.SerializeObject(infoes);
            var result = DownloadData<dynamic>.DownloadValue("https://localhost:44317/api/Step/UpdateInformation", "POST", json, Token);
            return View();
        }

        [HttpPost]
        public IActionResult Step3([FromForm]IFormCollection files)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Step4(string[] select1, string[] select2)
        {
            return View();
        }
    }
}
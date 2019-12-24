using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Panel.Classes;
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

        public IActionResult Result()
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
            var result = DownloadData<dynamic>.DownloadValue($"{ServerUrl.ServerAddress}/api/Step/UpdateInformation", "POST", json, Token);
            return Json(result.value.Value);
        }

        [HttpPost]
        public IActionResult Step2(HoghoghiViewModel model)
        {
            model.type = BEFOYS.DataLayer.Enums.Enum_UserType.Supplier_Legal;
            string Token = Get("token");
            model.StepNumber = 2;
            model.infoes[8].Value = model.infoes[8].Value == "on" ? "1" : "0";
            string json = JsonConvert.SerializeObject(model);
            var result = DownloadData<dynamic>.DownloadValue($"{ServerUrl.ServerAddress}/api/Step/UpdateInformation", "POST", json, Token);
            return Json(result.value.Value);
        }

        [HttpPost]
        public IActionResult Step4(string[] select1, string[] select2)
        {
            return Json(true);
        }

        public string Get(string key)
        {
            return Request.Cookies[key];
        }
    }
}
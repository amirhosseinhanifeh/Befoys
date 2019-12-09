using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Panel.DownloadData;

namespace Panel.Controllers
{
    public class StepController : Controller
    {
        public IActionResult Step1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Step1(Step1HA model)
        {

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
        public IActionResult Step2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Step2(StepValues[] model)
        {

            string Token = Get("token");
            //model.StepNumber = 1;
            string json = JsonConvert.SerializeObject(model);
            var result = DownloadData<dynamic>.DownloadValue("https://localhost:44317/api/Step/UpdateInformation", "POST", json, Token);
            return View();
        }
    }
    public class Step1HA
    {
        public int StepNumber { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public Enum_Gender Gender { get; set; }
        public string BirthDay { get { return $"{Year}/{Month}/{Day}"; } }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public StepValues[] infoes { get; set; }
    }
    public class Step1HO
    {
        public int StepNumber { get; set; }
        public string OrganizationName { get; set; }
        public StepValues[] infoes { get; set; }
    }

    public class StepValues
    {
        public int TypeCodeId { get; set; }
        public string Value { get; set; }
    }
    public class AddressValues
    {
        public int MyProperty { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.Model;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Panel.Classes;
using Panel.DownloadData;
using Panel.ViewModels.Account;

namespace Panel.Controllers
{
    public class HaghighiController : Controller
    {
        private IConverter _converter;

        public HaghighiController(IConverter converter)
        {
            _converter = converter;
        }

        public IActionResult Step1()
        {
            string Token = Get("token");
            var result = DownloadData<dynamic>.DownloadValue($"{ServerUrl.ServerAddress}/api/Step/GetInformation", "POST", "", Token);
            return View();
        }

        [HttpPost]
        public IActionResult Step1(HaghighiViewModel model)
        {
            model.type = BEFOYS.DataLayer.Enums.Enum_UserType.Supplier_Real;
            string Token = Get("token");
            model.StepNumber = 1;
            string json = JsonConvert.SerializeObject(model);
            var result = DownloadData<dynamic>.DownloadValue($"{ServerUrl.ServerAddress}/api/Step/UpdateInformation", "POST", json, Token);
            return Json(result.value.Value);
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
        public IActionResult Step2(HaghighiViewModel model)
        {
            string Token = Get("token");
            model.StepNumber = 2;
            model.infoes[3].Value = model.infoes[3].Value == "on" ? "1" : "0";
            string json = JsonConvert.SerializeObject(model);
            var result = DownloadData<dynamic>.DownloadValue($"{ServerUrl.ServerAddress}/api/Step/UpdateInformation", "POST", json, Token);
            return Json(result.value.Value);
        }

        [HttpPost]
        public IActionResult Step4(int[] select2)
        {
            string Token = Get("token");
            string json = JsonConvert.SerializeObject(select2);
            var result = DownloadData<dynamic>.DownloadValue($"{ServerUrl.ServerAddress}/api/Step/SetOrganizationCategory", "POST", json, Token);


            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"D:\PDFCreator\EmployeeReport.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(select2),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);

            return File(file, "application/pdf", "EmployeeReport.pdf");
        }
    }
}
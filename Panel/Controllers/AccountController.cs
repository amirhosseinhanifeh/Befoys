using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Panel.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Goto(string token)
        {
            Remove("token");
            Set("token", token, 2000);
            return RedirectToAction("Index","OrganizationType");
        }
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }
        public IActionResult Verify()
        {
            return View();
        }
        public string Get(string key)
        {
            return Request.Cookies[key];
        }
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
    }
}
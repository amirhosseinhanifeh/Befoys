using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Panel.Areas.Crm.Controllers
{
    [Area("Crm")]
    [Route("Crm/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly ServiceContext _context;

        public ProductController(ServiceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult Search(string Name)
        {
            return Json(_context.TblProduct.Where(x => x.ProductName.Contains(Name)).Select(y => new { y.ProductName,y.ProductId }).ToArray());
        }
        public async Task<IActionResult> List()
        {
            //var user = User.Identity.UserID();
            //var employee = _context.TblEmployee.FirstOrDefault(x => x.EmployeeLoginId == user);
            return View(await _context.TblProductOrganization.Where(x=>x.PoOrganizationId==2).ToListAsync());
        }
    }
}
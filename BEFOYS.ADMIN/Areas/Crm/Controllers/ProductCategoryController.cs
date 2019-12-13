using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.Crm.Controllers
{
    [Area("Crm")]
    [Route("Crm/[controller]/[action]")]
    public class ProductCategoryController : Controller
    {
        private readonly ServiceContext _context;

        public ProductCategoryController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProductCategory.ToListAsync());
        }
        public IActionResult Create(int? id)
        {
            ViewBag.ID = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblProductCategory model)
        {
            _context.TblProductCategory.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblProductCategory.Find(id);
            _context.TblProductCategory.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Panel.Areas.Crm.Controllers
{
    [Area("Crm")]
    [Route("Crm/[controller]/[action]/{id?}")]
    public class ProductDiscountController : Controller
    {
        private readonly ServiceContext _context;

        public ProductDiscountController(ServiceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.TblProductOrganizationDiscount.Where(x=>x.PodPoid==id).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create(int? id)
        {
            ViewBag.PodToCount = _context.TblProductOrganizationDiscount.AsEnumerable().LastOrDefault(x => x.PodPoid == id)?.PodToCount+1??1;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? id, TblProductOrganizationDiscount model)
        {
            if (!_context.TblProductOrganizationDiscount.Where(x =>x.PodPoid==id && (x.PodFromCount <= model.PodFromCount && x.PodToCount >= model.PodFromCount) || (x.PodFromCount <= model.PodToCount && x.PodToCount >= model.PodToCount)).Any())
                model.PodPoid = id.GetValueOrDefault();
            _context.TblProductOrganizationDiscount.Add(model);
           await _context.SaveChangesAsync();


            return View();
        }
        public IActionResult Delete(int? id)
        {
            var data = _context.TblProductOrganizationDiscount.Find(id);
            _context.TblProductOrganizationDiscount.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }
    }
}
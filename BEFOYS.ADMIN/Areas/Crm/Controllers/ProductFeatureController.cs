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
    public class ProductFeatureController : Controller
    {
        private readonly ServiceContext _context;

        public ProductFeatureController(ServiceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int CategoryID)
        {
            return View(await _context.TblProductFeatureGroup.Where(x => x.TblProductCategoryFeature.Any(x=>x.PcfPcid==CategoryID)).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblProductFeatureGroup model)
        {
            _context.TblProductFeatureGroup.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblProductFeatureGroup.Find(id);
            _context.TblProductFeatureGroup.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetFields(int? CategoryID) =>
            
            Json("");
        
    }
}
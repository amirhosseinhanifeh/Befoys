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
    [Route("Crm/[controller]/[action]/{id?}")]
    public class ProductCategoryController : Controller
    {
        private readonly ServiceContext _context;

        public ProductCategoryController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                ViewBag.Category = _context.TblProductCategory.Find(id);
                return View( await _context.TblProductCategory.Include(x=>x.InversePcPcd).Where(x => x.PcPcdid == id).ToListAsync());

            }
            return View(await _context.TblProductCategory.Include(x => x.InversePcPcd).Where(x=>x.PcPcdid==null).ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory(int? id)
        {
            var Result = _context.TblProductCategory.AsQueryable();
            if (id != null)
            {
                return Json(new {IsSubCategory=true, Options = await Result.Where(x => x.PcPcdid == id).Select(x => new { x.PcId, x.PcName }).ToArrayAsync() });

            }
            return Json(new { IsSubCategory = false,Options = await Result.Where(x => x.PcPcdid == null).Select(x => new { x.PcId, x.PcName }).ToArrayAsync() });
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
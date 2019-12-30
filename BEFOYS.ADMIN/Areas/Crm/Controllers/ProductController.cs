using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.Crm.Controllers
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

        public async Task<IActionResult> Index(int? PCID = null)
        {
            if (PCID.HasValue)
            {
                return View(await _context.TblProduct.Where(x => x.ProductPcid == PCID).ToListAsync());

            }
            return View(await _context.TblProduct.ToListAsync());
        }

        public async Task<IActionResult> Category()
        {

            return View(await _context.TblProductCategory.Include(x => x.InversePcPc).Where(x => x.PcPcid == null).Select(x => new SelectListItem
            {
                Value = x.PcId.ToString(),
                Text = x.PcName
            }).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> GetSubCategory(int? CategoryID)
        {
            return Json(await _context.TblProductCategory.Include(x => x.InversePcPc).Where(x => x.PcPcid == CategoryID).Select(x => new SelectListItem
            {
                Value = x.PcId.ToString(),
                Text = x.PcName
            }).ToListAsync());
        }

        public IActionResult SelectCategory()
        {
            return PartialView();
        }

        public IActionResult Create()
        {
            ViewBag.Brands = _context.TblBrands
                .Select(x => new SelectListItem { Value = x.BrandsId.ToString(), Text = x.BrandsName }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TblProduct model)
        {
            _context.TblProduct.Add(model);
            await _context.SaveChangesAsync();

            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblProduct.Find(id);
            _context.TblProduct.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
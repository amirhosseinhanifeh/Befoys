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
    public class ProductCategoryFeatureController : Controller
    {
        private readonly ServiceContext _context;

        public ProductCategoryFeatureController(ServiceContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int CategoryID)
        {
            return View(await _context.TblProductCategoryFeature.Where(x=>x.PcfPcid==CategoryID).ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.FeatureGroup = _context.TblProductFeatureGroup.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int id,int[] ids)
        {
            List<TblProductCategoryFeature> list = new List<TblProductCategoryFeature>();
            foreach (var item in ids)
            {
                list.Add(new TblProductCategoryFeature
                {
                    PcfPcid = id,
                    PcfPfgid = item
                });
            }
            _context.TblProductCategoryFeature.AddRange(list);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblProductCategoryFeature.Find(id);
            _context.TblProductCategoryFeature.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
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
    public class ProductController : Controller
    {
        private readonly ServiceContext _context;

        public ProductController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? PCID=null)
        {
            if(PCID.HasValue)
            {
                return View(await _context.TblProduct.Where(x=>x.ProductPcid== PCID).ToListAsync());

            }
            return View(await _context.TblProduct.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(TblProduct model)
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
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
    public class ProductColorController : Controller
    {
        private readonly ServiceContext _context;

        public ProductColorController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.TblProductColors.Where(x=>x.PcProductId==id).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? id,TblProductColors model)
        {
            model.PcProductId = id.GetValueOrDefault();
            _context.TblProductColors.Add(model);
            await _context.SaveChangesAsync();

            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblProductColors.Find(id);
            _context.TblProductColors.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
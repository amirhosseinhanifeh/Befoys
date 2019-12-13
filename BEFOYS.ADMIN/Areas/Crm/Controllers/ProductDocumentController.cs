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
    [Area("Setting")]
    [Route("Setting/[controller]/[action]/{id?}")]
    public class ProductDocumentController : Controller
    {
        private readonly ServiceContext _context;

        public ProductDocumentController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            return View(await _context.TblProductDocument.Where(x=>x.PdProductId==id).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblProductDocument model)
        {
            _context.TblProductDocument.Add(model);
            await _context.SaveChangesAsync();

            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblProductDocument.Find(id);
            _context.TblProductDocument.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
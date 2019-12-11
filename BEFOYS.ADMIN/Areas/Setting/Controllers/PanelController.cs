using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.Setting.Controllers
{
    public class PanelController : Controller
    {
        private readonly ServiceContext _context;

        public PanelController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TblPanelType.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblPanelType model)
        {
            _context.TblPanelType.Add(model);
            await _context.SaveChangesAsync();

            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblPanelType.Find(id);
            _context.TblPanelType.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
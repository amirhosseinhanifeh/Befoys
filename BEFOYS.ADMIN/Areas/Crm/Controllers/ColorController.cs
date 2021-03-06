﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.Crm.Controllers
{
    [Area("Crm")]
    [Route("Crm/[controller]/[action]/{id?}")]
    public class ColorController : Controller
    {
        private readonly ServiceContext _context;

        public ColorController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TblColors.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.ColorGroup = _context.TblColorsGroup.Select(x => new SelectListItem { Value = x.CgId.ToString(), Text = x.CgName }).ToList();
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblColors model)
        {
            _context.TblColors.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblColors.Find(id);
            _context.TblColors.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
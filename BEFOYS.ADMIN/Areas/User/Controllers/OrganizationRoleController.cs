using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]/{id?}")]
    public class OrganizationRoleController : Controller
    {
        private readonly ServiceContext _context;

        public OrganizationRoleController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            ViewBag.ID = id;
            return View(await _context.TblOrganizationRole.Where(x=>x.OrOrganizationId==id).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? id, TblOrganizationRole model)
        {
            model.OrOrganizationId = id.GetValueOrDefault();
            _context.TblOrganizationRole.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { id});
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblOrganizationRole.Find(id);
            _context.TblOrganizationRole.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
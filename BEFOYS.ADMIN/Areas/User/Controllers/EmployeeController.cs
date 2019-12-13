using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]/{id?}")]
    public class EmployeeController : Controller
    {
        private readonly ServiceContext _context;

        public EmployeeController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? OrId=null)
        {
            ViewBag.ID = OrId;
            if(OrId !=null)
            {
                return View(await _context.TblEmployee.Include(x=>x.TblEmployeeRegistrationCode).Where(x=>x.EmployeeOrganizationId==OrId).ToListAsync());
            }
            return View(await _context.TblEmployee.ToListAsync());
        }
        public IActionResult Create(int id)
        {
            ViewBag.Roles = _context.TblOrganizationRole.Where(x => x.OrOrganizationId == id).Select(x => new SelectListItem { Text = x.OrDisplay, Value = x.OrId.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? id,TblEmployee model)
        {
            model.EmployeeOrganizationId = id.GetValueOrDefault();
            _context.TblEmployee.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult RegisterationCode()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterationCode(int? id, TblEmployeeRegistrationCode model)
        {
            model.ErcEmployeeId = id.GetValueOrDefault();
            _context.TblEmployeeRegistrationCode.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblEmployee.Find(id);
            _context.TblEmployee.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Panel.Areas.Setting.Controllers
{
    public class OrganizationTransportController : Controller
    {
        private readonly ServiceContext _context;

        public OrganizationTransportController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Identity.UserID();
            return View(await _context.TblOrganizationTransport.Where(x => x.OtOrganization.TblEmployee.Any(x=>x.EmployeeLoginId==user)).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblOrganizationTransport model)
        {
            var user = _context.TblEmployee.FirstOrDefault(x => x.EmployeeLoginId == User.Identity.UserID());
            model.OtOrganizationId = user.EmployeeOrganizationId;
            _context.TblOrganizationTransport.Add(model);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.User.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly ServiceContext _context;

        public OrganizationController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TblOrganization.Where(x=>x.OrganizationIsActive==false).ToListAsync());
        }
    }
}
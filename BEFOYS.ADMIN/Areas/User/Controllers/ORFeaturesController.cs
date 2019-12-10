using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.User.Controllers
{
    public class ORFeaturesController : Controller
    {
        private readonly ServiceContext _context;

        public ORFeaturesController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if(id.HasValue)
            {
                return View(await _context.TblOrganizationInformation.Where(x=>x.OiOrganizationId==id).ToListAsync());
            }
            return View();
        }
        public async Task<IActionResult> UpdateStatus(int? id, bool? Status)
        {
            var Result =await _context.TblOrganizationInformation.FindAsync(id);
            Result.OiIsAccept = Status;
            await _context.SaveChangesAsync();
            return RedirectToAction("SendReason");
        }

        public IActionResult SendReason()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendReason(int? id ,string Text)
        {
            var orin =await _context.TblOrganizationInformation.FindAsync(id);
            orin.OiRejectDetails = Text;
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
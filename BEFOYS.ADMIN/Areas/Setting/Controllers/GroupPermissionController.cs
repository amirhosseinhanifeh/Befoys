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
    [Area("Setting")]
    [Route("Setting/[controller]/[action]/{id?}")]
    public class GroupPermissionController : Controller
    {
        private readonly ServiceContext _context;

        public GroupPermissionController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id=null )
        {
            ViewBag.ID = id;
            return View(await _context.TblGroupPermission.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? id, int[] permissions)
        {
            //var list = _context.TblPanelTypePermission.Where(x => x.PtpPtid == id).ToList();
            //_context.TblPanelTypePermission.RemoveRange(list);
            //foreach (var item in permissions)
            //{
            //    list.Add(new TblGroupPermission { GpPermissionId = item, GpGroupId = id.GetValueOrDefault(), PtpGuid = Guid.NewGuid() });
            //}
            //await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { id = id });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = _context.TblPanelTypePermission.Find(id);
            _context.TblPanelTypePermission.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
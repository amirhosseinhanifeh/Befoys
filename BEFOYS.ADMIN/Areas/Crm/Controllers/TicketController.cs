using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.ADMIN.Areas.Crm.Controllers
{
    public class TicketController : Controller
    {
        private readonly ServiceContext _context;

        public TicketController(ServiceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Identity.UserID();
            return View(await _context.TblTicket.Where(x => x.TicketSenderLoginId == user).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TblTicket model)
        {
            model.TicketSenderLoginId = User.Identity.UserID();
            _context.TblTicket.Add(model);
            await _context.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> Answer(int? id)
        {
            ViewBag.Ticket = _context.TblTicket.Find(id);
            return View(await _context.TblTicketAnswer.Where(x => x.TaTicketId == id).ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Answer(int? id, TblTicketAnswer model)
        {
            if (id == null)
            {
                return Redirect("~/");
            }
            model.TaSenderLoginId = User.Identity.UserID();
            model.TaTicketId = id.GetValueOrDefault();
            model.TaCreateDate = DateTime.Now;
            _context.TblTicketAnswer.Add(model);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
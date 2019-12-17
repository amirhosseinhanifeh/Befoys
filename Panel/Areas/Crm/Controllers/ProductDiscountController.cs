using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;

namespace Panel.Areas.Crm.Controllers
{
    public class ProductDiscountController : Controller
    {
        private readonly ServiceContext _context;

        public ProductDiscountController(ServiceContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? POid)
        {
            return View();
        }
        public IActionResult Create(int? POid)
        {
            return View(_context.TblProductOrganizationDiscount.AsEnumerable().LastOrDefault(x=>x.PodPoid==POid));
        }
        [HttpPost]
        public async Task<IActionResult> Create(int? POid, TblProductOrganizationDiscount model)
        {
            if (!_context.TblProductOrganizationDiscount.Where(x => (x.PodFromCount <= model.PodFromCount && x.PodToCount >= model.PodFromCount) || (x.PodFromCount <= model.PodToCount && x.PodToCount >= model.PodToCount)).Any())
                model.PodPoid = POid.GetValueOrDefault();
            _context.TblProductOrganizationDiscount.Add(model);
           await _context.SaveChangesAsync();


            return View();
        }
    }
}
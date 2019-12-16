using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Panel.Areas.Crm.Controllers
{
    [Area("Crm")]
    [Route("Crm/[controller]/[action]/{id?}")]
    public class ProductQuantityController : Controller
    {
        private readonly ServiceContext _context;

        public ProductQuantityController(ServiceContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id=null)
        {
            if (id == null)
            {
                return Redirect("~/");
            }
            ViewBag.ID = id;

            return View(_context.TblProductOrganizationQuantity.Where(x => x.PoqPo.PoProductId == id && x.PoqPo.PoOrganizationId==2).ToList());
        }
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return Redirect("~/");
            }
            ViewBag.Colors = _context.TblProductColors.Where(x => x.PcProductId == id).Select(y => new SelectListItem { Value = y.PcColorsId.ToString(), Text = y.PcColors.ColorsName }).ToList();
            ViewBag.Provinces = _context.TblProvince.Select(y => new SelectListItem { Value = y.ProvinceId.ToString(), Text = y.ProvinceDisplay }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(int? id, TblProductOrganizationQuantity model)
        {

            if (!_context.TblProductOrganizationQuantity.Where(x => x.PoqColorId == model.PoqColorId && x.PoqProvinceId == model.PoqProvinceId && x.PoqPo.PoProductId == id && x.PoqPo.PoOrganizationId==2).Any())
            {
                model.PoqPoid = _context.TblProductOrganization.FirstOrDefault(x => x.PoProductId == id && x.PoOrganizationId == 2).PoId;
                _context.TblProductOrganizationQuantity.Add(model);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index",new {id });
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int? id,ViewProductQuantity[] model)
        {

            foreach (var item in model)
            {
                var Result = _context.TblProductOrganizationQuantity.Find(item.PoqId);
                Result.PoqInventory = item.PoqInventory;
                Result.PoqBasePrice = item.PoqBasePrice;
                _context.SaveChanges();
            }
            ViewBag.Message = "با موفقیت ثبت شد";
            ViewBag.ID = id;
            return View("Index", _context.TblProductOrganizationQuantity.Where(x => x.PoqPo.PoProductId == id && x.PoqPo.PoOrganizationId == 2).ToList());
        }
        public IActionResult Delete(int? id,int? POId=null)
        {
            var Result = _context.TblProductOrganizationQuantity.Find(id);
            _context.TblProductOrganizationQuantity.Remove(Result);
            _context.SaveChanges();
            return RedirectToAction("Index",new {id=POId });
        }
    }
}
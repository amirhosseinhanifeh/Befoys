using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index(int? id)
        {
            return View();
        }
    }
}
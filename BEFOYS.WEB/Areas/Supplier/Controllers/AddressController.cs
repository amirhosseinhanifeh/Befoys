using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.DataLayer.Entity.Address;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Supplier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private ServiceContext _context;

        public AddressController(ServiceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tbl_Address>>> Get()
        {
            var user = User.Identity.UserID();
            return await _context.Tbl_Address.ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Entity.Address;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Supplier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PhoneController : ControllerBase
    {
        private ServiceContext _context;

        public PhoneController(ServiceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Tbl_Phone>>> Get()
        {
            return await _context.Tbl_Phone.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tbl_Phone>>> Get(int? id)
        {
            return await _context.Tbl_Phone.Where(y=>y.Phone_AddressID==id).ToListAsync();
        }
    }
}
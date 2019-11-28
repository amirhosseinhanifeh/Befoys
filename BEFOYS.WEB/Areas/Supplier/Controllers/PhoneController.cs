using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Supplier.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<ActionResult<List<TblPhone>>> Get()
        {
            return await _context.TblPhone.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TblPhone>>> Get(int? id)
        {
            return await _context.TblPhone.Where(y=>y.PhoneAddressId==id).ToListAsync();
        }
    }
}
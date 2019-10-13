using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public RoleController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody]ViewBaseRole model)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_BaseRole>>> Get()
        {
            return await _context.Tbl_BaseRole.ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
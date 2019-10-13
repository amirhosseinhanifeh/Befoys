using BEFOYS.DataLayer.Entity.Permission;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public PermissionController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody]ViewPermission model)
        {
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Permission>>> Get()
        {
            return await _context.Tbl_Permission.ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
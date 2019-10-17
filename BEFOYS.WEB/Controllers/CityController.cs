using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.City;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.City;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public CityController(ServiceContext context)
        {
            _context = context;
        }


        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]ViewCity model)
        {
            try
            {
                Tbl_City ci = new Tbl_City()
                {
                    City_Name = model.Name,
                    City_Display = model.Display
                };
                await _context.Tbl_City.AddAsync(ci);
                await _context.SaveChangesAsync();
                return Ok(new BaseViewModel<Tbl_City> { Value = ci, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success });

            }
            catch (Exception e)
            {
                return Ok(new BaseViewModel<string> { Value = e.Message, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_City>>> Get()
        {

            return await _context.Tbl_City.ToListAsync();
        }
        [HttpGet("{Province_ID}")]
        public async Task<ActionResult<IEnumerable<Tbl_City>>> Get(int? Province_ID = null)
        {
            return await _context.Tbl_City.Where(x => x.City_ProvinceID == Province_ID).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_City>>> Delete(int? id)
        {
            try
            {
                var data = await _context.Tbl_City.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_City.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_City> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_City> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

            }
            catch (Exception e)
            {
                return Ok(new BaseViewModel<string> { Value = e.Message, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
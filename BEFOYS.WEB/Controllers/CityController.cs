using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.City;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.City;
using BEFOYS.DataLayer.ViewModels.Province;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase,IDisposable
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
        public async Task<IActionResult> Post([FromBody]ViewCity model)
        {
            try
            {
                Tbl_City ci = new Tbl_City()
                {

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
        public async Task<ActionResult<IEnumerable<Tbl_City>>> Get(int? Province_ID=null)
        {
            if (Province_ID != null)
            {
                //return Ok(await _context.Tbl_City.Where(x => x.Province_ID == model.Province_ID).ToListAsync());

            }
            return await _context.Tbl_City.ToListAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var data =await _context.Tbl_City.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_City.Remove(data);
                    await _context.SaveChangesAsync();
                    return Ok(new BaseViewModel<Tbl_City> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success });
                }
                return Ok(new BaseViewModel<Tbl_City> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound });

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
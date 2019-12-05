using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
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
        public async Task<BaseViewModel<bool>> Post([FromBody]ViewCity model)
        {
            try
            {
                TblCity ci = new TblCity()
                {
                    CityName = model.Name,
                    CityDisplay = model.Display
                };
                await _context.TblCity.AddAsync(ci);
                await _context.SaveChangesAsync();
                return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCity>>> Get()
        {

            return await _context.TblCity.ToListAsync();
        }
        [HttpGet("{Province_ID}")]
        public async Task<ActionResult<IEnumerable<TblCity>>> Get(int? Province_ID = null)
        {
            return await _context.TblCity.Where(x => x.CityProvinceId == Province_ID).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblCity>>> Delete(int? id)
        {
            try
            {
                var data = await _context.TblCity.FindAsync(id);
                if (data != null)
                {
                    _context.TblCity.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblCity> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblCity> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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
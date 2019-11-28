using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Province;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProvinceController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public ProvinceController(ServiceContext context)
        {
            _context = context;
        }
        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblProvince>>> Post([FromBody]ViewProvince model)
        {
            try
            {
                TblProvince pr = new TblProvince()
                {
                    ProvinceCityId=model.CityID,
                    ProvinceDisplay=model.Display,
                    ProvinceName=model.Name,
                    
                };
                await _context.TblProvince.AddAsync(pr);
                await _context.SaveChangesAsync();
                return new BaseViewModel<TblProvince> { Value = pr, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<TblProvince> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProvince>>> Get()
        {
            return await _context.TblProvince.ToListAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
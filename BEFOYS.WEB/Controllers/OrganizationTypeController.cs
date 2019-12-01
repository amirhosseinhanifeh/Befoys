using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganizationTypeController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public OrganizationTypeController(ServiceContext context)
        {
            _context = context;
        }
        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblOrganizationType>>> Post([FromBody]string model)
        {
            try
            {
                //TblOrganizationType pr = new TblOrganizationType()
                //{
                //    ProvinceCityId = model.CityID,
                //    ProvinceDisplay = model.Display,
                //    ProvinceName = model.Name,

                //};
                //await _context.TblProvince.AddAsync(pr);
                //await _context.SaveChangesAsync();
                return new BaseViewModel<TblOrganizationType> { Value = null, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<TblOrganizationType> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOrganizationType>>> Get()
        {
            return await _context.TblOrganizationType.ToListAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
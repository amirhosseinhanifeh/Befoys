using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Address;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.City;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Supplier.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private ServiceContext _context;

        public AddressController(ServiceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_Address>>> Post([FromBody]ViewAdress model)
        {
            try
            {
                var user = User.Identity.UserID();
                if (model.Address_ID != null)
                {
                    var result = await _context.Tbl_Address.FindAsync(model.Address_ID);
                    result.Address_Text = model.Address_Text;
                    result.Address_ISSetGPS = false;
                    result.Address_GPSLong = model.Address_GPSLong;
                    result.Address_GPSLat = model.Address_GPSLat;
                    result.Address_CityID = model.Address_CityID;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_Address> { Value = result, Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                Tbl_Address address = new Tbl_Address()
                {
                    Address_GPSLat = model.Address_GPSLat,
                    Address_GPSLong = model.Address_GPSLong,
                    Address_CityID = model.Address_CityID,
                    Address_ISSetGPS = true,
                    Address_LoginID = user,
                    Address_Text = model.Address_Text,
                    
                };
                _context.Tbl_Address.Add(address);
                await _context.SaveChangesAsync();

                return new BaseViewModel<Tbl_Address> { Value = address, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_Address> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Tbl_Address>>> Get()
        {
            var user = User.Identity.UserID();
            return await _context.Tbl_Address.Where(x=>x.Address_LoginID==user).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_Address>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.Tbl_Address.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_Address.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_Address> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_Address> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

            }
            catch (Exception e)
            {
                return Ok(new BaseViewModel<string> { Value = e.Message, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
            }
        }
    }
}
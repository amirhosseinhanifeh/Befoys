using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public ProductController(ServiceContext context)
        {
            _context = context;
        }
        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<BaseViewModel<TblProduct>> Post([FromBody]ViewProduct model)
        {
            try
            {
                TblProduct pr = new TblProduct();
                await _context.TblProduct.AddAsync(pr);
                await _context.SaveChangesAsync();
                return new BaseViewModel<TblProduct> { Value = pr, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<TblProduct> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProduct>>> Get()
        {

            return await _context.TblProduct.ToListAsync();
        }
        //[HttpGet("{Province_ID}")]
        //public async Task<ActionResult<IEnumerable<TblProduct>>> Get(int? Province_ID = null)
        //{
        //    return await _context.TblProduct.Where(x => x.ProductId == Province_ID).ToListAsync();
        //}
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblProduct>>> Delete(int? id)
        {
            try
            {
                var data = await _context.TblProduct.FindAsync(id);
                if (data != null)
                {
                    _context.TblProduct.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblProduct> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblProduct> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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
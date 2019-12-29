using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.ProductCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public ProductCategoryController(ServiceContext context)
        {
            _context = context;
        }
        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Post([FromBody]ViewProductCategory model)
        {
            try
            {
                TblProductCategory cat = new TblProductCategory()
                {
                    PcCommission=model.PcCommission,
                    PcDisplay=model.PcDisplay,
                    PcIsActive=model.PcIsActive,
                    PcName=model.PcName,
                    PcIsBase=model.PcIsBase,
                };
                await _context.TblProductCategory.AddAsync(cat);
                await _context.SaveChangesAsync();
                return new BaseViewModel<bool> { Value =true , Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProductCategory>>> Get()
        {
            return await _context.TblProductCategory.Include(x=>x.InversePcPc).Where(x=>x.PcPcid==null).ToListAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
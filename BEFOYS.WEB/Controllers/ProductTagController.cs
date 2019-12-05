using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductTagController : ControllerBase,IDisposable
    {
        private readonly ServiceContext _context;

        public ProductTagController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Post([FromBody]ViewProductTags model)
        {
            try
            {
                TblTags tags = new TblTags()
                {
                    TagsName = model.TagsName
                };
                _context.TblTags.Add(tags);
                await _context.SaveChangesAsync();

                TblProductTags pt = new TblProductTags()
                {
                    PtProductId=model.ProductID,
                    PtTagsId=tags.TagsId,
                };
                _context.TblProductTags.Add(pt);
                await _context.SaveChangesAsync();

                return new BaseViewModel<bool> { Value =true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProductTags>>> Get()
        {
            return await _context.TblProductTags.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.TblProductTags.FindAsync(id);
                if (data != null)
                {
                    _context.TblProductTags.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<bool> { Value = true, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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
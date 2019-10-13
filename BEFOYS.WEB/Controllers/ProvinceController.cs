﻿using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Province;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Province;
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
        public async Task<IActionResult> Post([FromBody]ViewProvince model)
        {
            try
            {
                Tbl_Province pr = new Tbl_Province()
                {

                };
                await _context.Tbl_Province.AddAsync(pr);
                await _context.SaveChangesAsync();
                return Ok(new BaseViewModel<Tbl_Province> { Value = pr, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success });

            }
            catch (Exception e)
            {
                return Ok(new BaseViewModel<string> { Value = e.Message, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Province>>> Get()
        {
            return await _context.Tbl_Province.ToListAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
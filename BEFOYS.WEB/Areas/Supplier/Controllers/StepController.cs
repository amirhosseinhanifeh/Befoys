using BEFOYS.Common.AppUser;
using BEFOYS.DataLayer.Entity.Address;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Register.Step;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BEFOYS.WEB.Areas.Supplier.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StepController : ControllerBase
    {
        private ServiceContext _context;

        public StepController(ServiceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Step1()
        {
            var user = User.Identity.UserID();
            var supplier = _context.Tbl_Supplier.Include(x => x.Code).FirstOrDefault(x => x.Supplier_LoginID == user);
            if (supplier.Code.Code_Display == "HAGHIGHI")
            {
                var real = supplier.SupplierReals.FirstOrDefault();
                return Ok(new ViewStep1
                {
                    BirthDay = real.SR_Birthday,
                    Gender = (Enum_Gender)real.SR_GenderCodeID.GetValueOrDefault(),
                    NationalCode = real.SR_NationalCode,
                });
            }
            else
            {
                var legal = supplier.SupplierLegals.FirstOrDefault();
                return Ok(new ViewStep1
                {
                    EconomicCode = legal.SL_EconomicCode,
                    CompanyName=legal.SL_CompanyName
                });
            }
        }
        [HttpPost]
        public IActionResult Step1([FromBody]ViewStep1 model)
        {
            var userId = User.Identity.UserID();
            var user = _context.Tbl_Supplier.Include(x => x.Code).FirstOrDefault(x => x.Supplier_LoginID == userId);
            user.Supplier_Website = model.Website;
            if (user.Code.Code_Display == Enum_UserType.HAGHIGHI.ToString())
            {
                var real = _context.Tbl_SupplierReal.FirstOrDefault(x => x.SR_SupplierID == user.Supplier_ID);
                real.SR_Birthday = model.BirthDay;
                real.SR_GenderCodeID = (int)model.Gender;
                real.SR_NationalCode = model.NationalCode;
                real.SR_ShenasnameID = model.IdNumber;

            }
            else
            {
                var code = _context.Tbl_Code.FirstOrDefault(x => x.Code_GUID == model.CompanyType);
                var legal = _context.Tbl_SupplierLegal.FirstOrDefault(x => x.SL_SupplierID == user.Supplier_ID);
                legal.SL_CompanyName = model.CompanyName;
                legal.SL_EconomicCode = model.EconomicCode;
                legal.SL_SabtNumber = model.RegisteredNumber;
                legal.SL_NationalCode = model.ShenaseID;
                legal.SL_CompanyTypeCodeID = code.Code_ID;
            }
            if (model.Addresses != null)
            {
                List<Tbl_Address> list = new List<Tbl_Address>();
                foreach (var item in model.Addresses)
                {
                    var city = _context.Tbl_City.FirstOrDefault(x => x.City_GUID == item.CityID);
                    Tbl_Address address = new Tbl_Address
                    {
                        Address_LoginID = userId,
                        Address_Text = item.Address,
                        Address_CityID = city.City_ID,
                    };
                    foreach (var item2 in item.Phones)
                    {
                        address.Phones = new List<Tbl_Phone>();
                        address.Phones.Add(new Tbl_Phone
                        {
                            Phone_Number = item2.Phone,

                        });
                    }
                    list.Add(address);
                }
            }

            _context.SaveChanges();
            return Ok(model);
        }
        [HttpPost]
        public IActionResult Step2([FromBody]ViewStep2 model)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Step3([FromBody]ViewStep3 model)

        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Step4()
        {
            return Ok();
        }
    }
}
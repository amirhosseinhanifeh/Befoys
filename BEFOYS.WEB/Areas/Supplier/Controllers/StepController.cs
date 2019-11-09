﻿using BEFOYS.Common.AppUser;
using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Address;
using BEFOYS.DataLayer.Entity.Supplier;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.Helpers;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Register.Step;
using BEFOYS.DataLayer.ViewModels.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        #region Step1 POST & GET

        [HttpGet]
        public async Task<IActionResult> Step1()
        {
            var user = User.Identity.UserID();

            var supplier = await _context.Tbl_Supplier
                .Include(x => x.Code)
                .Include(x => x.Login)
                .Include(x => x.SupplierLegals)
                .Include(x => x.SupplierReals)
                .FirstOrDefaultAsync(x => x.Supplier_LoginID == user);

            if (supplier.Code.Code_Display == "HAGHIGHI")
            {
                var real = supplier.SupplierReals.FirstOrDefault();

                return Ok(new ViewStep1Haghighi(real));
            }
            else
            {
                var legal = supplier.SupplierLegals.FirstOrDefault();
                return Ok(new ViewStep1Hoghoghi(legal));
            }
        }
        //[HttpPost]
        //public async Task<BaseViewModel<string>> Step1([FromBody]ViewStep1 model)
        //{
        //    try
        //    {

        //        var userId = User.Identity.UserID();
        //        var user = await _context.Tbl_Supplier.Include(x => x.Code).FirstOrDefaultAsync(x => x.Supplier_LoginID == userId);
        //        user.Supplier_Website = model.Website;
        //        if (user.Code.Code_Display == Enum_UserType.HAGHIGHI.ToString())
        //        {
        //            var real = await _context.Tbl_SupplierReal.FirstOrDefaultAsync(x => x.SR_SupplierID == user.Supplier_ID);
        //            real.SR_Birthday = model.Haghighi.SR_Birthday;
        //            real.SR_GenderCodeID = (int)model.Haghighi.Gender;
        //            real.SR_NationalCode = model.Haghighi.SR_NationalCode;
        //            real.SR_ShenasnameID = model.Haghighi.SR_ShenasnameID;

        //        }
        //        else
        //        {
        //            Guid CompanyTypeCodeGUID = model.Hoghoghi.SL_CompanyTypeCodeGUID.ToGuid();
        //            var code = _context.Tbl_Code.FirstOrDefault(x => x.Code_GUID == CompanyTypeCodeGUID);
        //            var legal = _context.Tbl_SupplierLegal.FirstOrDefault(x => x.SL_SupplierID == user.Supplier_ID);
        //            legal.SL_CompanyName = model.Hoghoghi.SL_CompanyName;
        //            legal.SL_EconomicCode = model.Hoghoghi.SL_EconomicCode;
        //            legal.SL_SabtNumber = model.Hoghoghi.SL_SabtNumber;
        //            legal.SL_NationalCode = model.Hoghoghi.SL_NationalCode;
        //            legal.SL_CompanyTypeCodeID = code?.Code_ID;
        //        }
        //        if (model.Addresses != null)
        //        {
        //            List<Tbl_Address> list = new List<Tbl_Address>();
        //            foreach (var item in model.Addresses)
        //            {
        //                Guid iguid = item.CityID.ToGuid();
        //                var city = _context.Tbl_City.FirstOrDefault(x => x.City_GUID == iguid);
        //                Tbl_Address address = new Tbl_Address
        //                {
        //                    Address_LoginID = userId,
        //                    Address_Text = item.Address,
        //                    Address_CityID = city.City_ID,
        //                };
        //                foreach (var item2 in item.Phones)
        //                {
        //                    address.Phones = new List<Tbl_Phone>
        //                    {
        //                        new Tbl_Phone
        //                        {
        //                            Phone_Number = item2.Phone,

        //                        }
        //                    };
        //                }
        //                list.Add(address);
        //            }
        //        }

        //        await _context.SaveChangesAsync();
        //        return new BaseViewModel<string> { Value = "", Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

        //    }
        //    catch (Exception e)
        //    {
        //        return new BaseViewModel<string>
        //        {
        //            Value = e.Message,
        //            Message = ViewMessage.Error,
        //            NotificationType = DataLayer.Enums.Enum_NotificationType.error
        //        };
        //    }
        //}
        #endregion


        #region Step2 POST& GET

        [HttpGet]
        public async Task<BaseViewModel<ViewStep2>> Step2()
        {
            try
            {
                var user = User.Identity.UserID();
                var supplier = await _context.Tbl_Supplier.FirstOrDefaultAsync(x => x.Supplier_LoginID == user);
                return new BaseViewModel<ViewStep2> { Value = new ViewStep2(supplier), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewStep2> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }

        [HttpPost]
        public async Task<BaseViewModel<string>> Step2([FromBody]ViewStep2 model)
        {
            try
            {
                var user = User.Identity.UserID();
                var supplier = _context.Tbl_Supplier.FirstOrDefault(x => x.Supplier_LoginID == user);
                supplier.Supplier_MaxSupply = model.Supplier_MaxSupply;
                supplier.Supplier_Sheba = model.Supplier_Sheba;
                supplier.Supplier_AccountName = model.Supplier_AccountName;
                supplier.Supplier_AccountNumber = model.Supplier_AccountNumber;
                supplier.Supplier_Govahi = model.Supplier_Govahi;
                supplier.Supplier_Brand = model.Supplier_Brand;
                supplier.Supplier_CategoryID = model.Supplier_CategoryID;
                await _context.SaveChangesAsync();
                return new BaseViewModel<string> { Value = "", Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<string> { Value = e.Message, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }

        }

        #endregion


        #region Step3 POST & GET
        [HttpGet]
        public async Task<BaseViewModel<ViewStep3>> Step3()
        {
            try
            {
                var user = User.Identity.UserID();
                var supplier = await _context.Tbl_Supplier.FirstOrDefaultAsync(x => x.Supplier_LoginID == user);
                return new BaseViewModel<ViewStep3> { Value = new ViewStep3(), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewStep3>
                {
                    Value = new ViewStep3(),
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<BaseViewModel<ViewStep3>> Step3([FromForm]ViewStep3 model)
        {
            try
            {
                var user = User.Identity.UserID();
                var supplier = await _context.Tbl_Supplier.Include(x => x.Code).FirstOrDefaultAsync(x => x.Supplier_LoginID == user);
                List<Tbl_SupplierDocument> suDocuments = new List<Tbl_SupplierDocument>();
                if (supplier.Code.Code_Display == Enum_Code.HAGHIGHI.ToString())
                {
                    string folder = User.Identity.Name;
                    var shenasname = await model.Shenasname.Upload(folder, _context, Enum_Code.PICTURE);
                    var mellicart = await model.MelliCart.Upload(folder, _context, Enum_Code.PICTURE);
                    var javazkasb = await model.JavazKasb.Upload(folder, _context, Enum_Code.PICTURE);
                    var govahi = await model.Govahi.Upload(folder, _context, Enum_Code.PICTURE);

                    suDocuments = new List<Tbl_SupplierDocument>();
                    if (shenasname != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = shenasname, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.SHENASNAME });
                    if (mellicart != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = mellicart, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.MELLICART });
                    if (javazkasb != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = javazkasb, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.JAVAZKASB });
                    if (govahi != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = govahi, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.GOVAHI });
                }
                else
                {
                    string folder = User.Identity.Name;
                    var roznamerasmi = await model.RoznameRasmi.Upload(folder, _context, Enum_Code.PICTURE);
                    var asasname = await model.Asasname.Upload(folder, _context, Enum_Code.PICTURE);
                    var Agahi = await model.Agahi.Upload(folder, _context, Enum_Code.PICTURE);
                    var govahi = await model.Govahi.Upload(folder, _context, Enum_Code.PICTURE);

                    suDocuments = new List<Tbl_SupplierDocument>();
                    if (roznamerasmi != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = roznamerasmi, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.ROZNAMERASMI });
                    if (asasname != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = asasname, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.ASASNAME });
                    if (Agahi != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = Agahi, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.AGAHI });
                    if (govahi != 0)
                        suDocuments.Add(new Tbl_SupplierDocument { SD_DocumentID = govahi, SD_SupplierID = supplier.Supplier_ID, SD_TypeCodeID = (int)Enum_Code.GOVAHI });
                }

                _context.Tbl_SupplierDocument.AddRange(suDocuments);
                await _context.SaveChangesAsync();

                return new BaseViewModel<ViewStep3> { Value = null, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewStep3>
                {
                    Value = null,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }
        #endregion


        [HttpGet]
        public IActionResult Step4()
        {
            return Ok();
        }

        #region AGENTS POST & GET

        
        [HttpGet]
        public async Task<BaseViewModel<List<ViewSupplierAgent>>> Agents()
        {
            try
            {
                var user = User.Identity.UserID();
                var supplier =await _context.Tbl_SupplierLegal.Include(x=>x.SupplierLegalAgents).FirstOrDefaultAsync(x => x.Supplier.Supplier_LoginID == user);
                var Result=  supplier.SupplierLegalAgents.Select(y=>new ViewSupplierAgent(y)).ToList();
                return new BaseViewModel<List<ViewSupplierAgent>> { Value = Result, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<List<ViewSupplierAgent>>
                {
                    Value = null,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }

        }
        [HttpPost]
        public async Task<BaseViewModel<Tbl_SupplierLegalAgent>> Agents([FromBody] ViewSupplierAgent model)
        {
            try
            {
                Tbl_SupplierLegalAgent data = new Tbl_SupplierLegalAgent()
                {
                    SLA_Family = model.SLA_Family,
                    SLA_Mobile = model.SLA_Mobile,
                    SLA_Name = model.SLA_Name,
                    SLA_NationalCode = model.SLA_NationalCode,
                    SLA_ShenasnameID = model.SLA_ShenasnameID,
                    SLA_GenderCodeID = model.SLA_GenderCodeID,
                    SLA_TypeCodeID = model.SLA_TypeCodeID
                };
                _context.Tbl_SupplierLegalAgent.Add(data);
                await _context.SaveChangesAsync();
                return new BaseViewModel<Tbl_SupplierLegalAgent> { Value = data, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_SupplierLegalAgent>
                {
                    Value = null,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }
        #endregion
    }
}
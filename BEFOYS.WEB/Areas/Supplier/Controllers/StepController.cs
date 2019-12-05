using BEFOYS.Common.AppUser;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.Helpers;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Organization;
using BEFOYS.DataLayer.ViewModels.Register.Step;
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

        #region OrganizationType

        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> SetOrganizationType([FromQuery]Enum_UserType type)
        {
            try
            {
                var user = User.Identity.UserID();
                var ot = await _context.TblOrganizationType.FirstOrDefaultAsync(x => x.OtName == type.ToString());
                var de = await _context.TblPanelType.FirstOrDefaultAsync(x => x.PtName == Enum_PanelType.DEFAULT.ToString());
                TblOrganization organization = new TblOrganization()
                {
                    OrganizationDefaultPtid = de.PtId,
                    OrganizationIsActive = true,
                    OrganizationIsBan = false,
                    OrganizationIsRegistar = true,
                    OrganizationIsDelete = false,
                    OrganizationCreateDate = DateTime.Now,
                    OrganizationIsMotherOrganization = true,
                    OrganizationOtid = ot.OtId,
                };
                _context.TblOrganization.Add(organization);
                await _context.SaveChangesAsync();
                TblEmployee empl = new TblEmployee()
                {
                    EmployeeLoginId = user,
                    EmployeeOrganizationId = organization.OrganizationId,
                    EmployeeIsAgent = true,
                    EmployeeWalletSize = -1
                };
                _context.TblEmployee.Add(empl);
                await _context.SaveChangesAsync();
                return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<bool>
                {
                    Value = false,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }
        #endregion

        #region Step1 POST & GET


        [HttpGet]
        public async Task<ActionResult<BaseViewModel<List<ViewOrganizationInformation>>>> GetInformation()
        {
            var user = User.Identity.UserID();

            var info = await _context.TblOrganizationInformation
                .Include(x => x.OiTypeCode)
                .Where(x => x.OiOrganization.TblEmployee.Any(y => y.EmployeeLoginId == user))
                .Select(x => new ViewOrganizationInformation(x)).ToListAsync();


            return new BaseViewModel<List<ViewOrganizationInformation>> { Message = "موفقیت آمیز", NotificationType = Enum_NotificationType.success, Value = info };

        }


        [HttpPost]
        public async Task<BaseViewModel<bool>> UpdateInformation([FromBody]UpdateInformation[] model)
        {
            try
            {
                var userId = User.Identity.UserID();
                var organization = _context.TblEmployee.FirstOrDefault(x => x.EmployeeLoginId == userId);
                foreach (var item in model)
                {
                    var info = await _context.TblOrganizationInformation.FirstOrDefaultAsync(x => x.OiTypeCodeId == item.TypeCodeId && x.OiOrganizationId == organization.EmployeeOrganizationId);
                    if (info == null)
                    {
                        TblOrganizationInformation tblOrganizationInformation = new TblOrganizationInformation()
                        {
                            OiIsAccept = null,
                            OiOrganizationId = organization.EmployeeOrganizationId,
                            OiText = item.Value,
                            OiTypeCodeId = item.TypeCodeId
                        };
                        _context.TblOrganizationInformation.Add(tblOrganizationInformation);

                    }
                    else
                    {
                        info.OiText = item.Value;
                    }
                    await _context.SaveChangesAsync();

                }

                //user.Supplier_Website = model.Website;
                //if (user.Code.Code_Display == Enum_UserType.Supplier_Legal.ToString())
                //{
                //    var real = await _context.TblOrganizationInformation.FirstOrDefaultAsync(x => x.OiOrganizationId == user && x.OiTypeCodeId==);
                //    real.SR_Birthday = model.Haghighi.SR_Birthday;
                //    real.SR_GenderCodeID = (int)model.Haghighi.Gender;
                //    real.SR_NationalCode = model.Haghighi.SR_NationalCode;
                //    real.SR_ShenasnameID = model.Haghighi.SR_ShenasnameID;

                //}
                //else
                //{
                //    Guid CompanyTypeCodeGUID = model.Hoghoghi.SL_CompanyTypeCodeGUID.ToGuid();
                //    var code = _context.Tbl_Code.FirstOrDefault(x => x.Code_GUID == CompanyTypeCodeGUID);
                //    var legal = _context.Tbl_SupplierLegal.FirstOrDefault(x => x.SL_SupplierID == user.Supplier_ID);
                //    legal.SL_CompanyName = model.Hoghoghi.SL_CompanyName;
                //    legal.SL_EconomicCode = model.Hoghoghi.SL_EconomicCode;
                //    legal.SL_SabtNumber = model.Hoghoghi.SL_SabtNumber;
                //    legal.SL_NationalCode = model.Hoghoghi.SL_NationalCode;
                //    legal.SL_CompanyTypeCodeID = code?.Code_ID;
                //}
                //if (model.Addresses != null)
                //{
                //    List<Tbl_Address> list = new List<Tbl_Address>();
                //    foreach (var item in model.Addresses)
                //    {
                //        Guid iguid = item.CityID.ToGuid();
                //        var city = _context.Tbl_City.FirstOrDefault(x => x.City_GUID == iguid);
                //        Tbl_Address address = new Tbl_Address
                //        {
                //            Address_LoginID = userId,
                //            Address_Text = item.Address,
                //            Address_CityID = city.City_ID,
                //        };
                //        foreach (var item2 in item.Phones)
                //        {
                //            address.Phones = new List<Tbl_Phone>
                //            {
                //                new Tbl_Phone
                //                {
                //                    Phone_Number = item2.Phone,

                //                }
                //            };
                //        }
                //        list.Add(address);
                //    }
                //}
                return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool>
                {
                    Value = false,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }
        #endregion
        [HttpPost]
        public ActionResult<BaseViewModel<bool>> CreateAddress()
        {
            try
            {
                return new BaseViewModel<bool>
                {
                    Message = "آدرس ذخیر شد",
                    NotificationType = Enum_NotificationType.success,
                    Value = true
                };
            }
            catch (Exception e)
            {

                throw;
            }
        }


        #region Step3 POST & GET

        [HttpPost, DisableRequestSizeLimit]
        public async Task<BaseViewModel<ViewStep3>> Step3([FromForm]ViewStep3 model)
        {
            try
            {
                var userId = User.Identity.UserID();
                var organization = _context.TblEmployee.FirstOrDefault(x => x.EmployeeLoginId == userId);
                foreach (var item in model.files)
                {
                    string folder = User.Identity.Name;
                    var doc = await item.Upload(folder, _context, Enum_Code.PICTURE);
                    TblOrganizationDocument data = new TblOrganizationDocument()
                    {
                        OdDocumentId = doc,
                        OdIsAccept = null,
                        OdOrganizationId = organization.EmployeeOrganizationId,

                    };
                    _context.TblOrganizationDocument.Add(data);
                    await _context.SaveChangesAsync();
                }
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
    }
}
﻿using BEFOYS.Common.AppUser;
using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.Helpers;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Organization;
using BEFOYS.DataLayer.ViewModels.Register.Step;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
                if (!_context.TblEmployee.Any(x => x.EmployeeLoginId == user))
                {
                    TblOrganization organization = new TblOrganization()
                    {
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
                        EmployeeWalletSize = -1,
                        EmployeeTypeCodeId = (int)Enum_Code.CEO

                    };
                    _context.TblEmployee.Add(empl);
                    await _context.SaveChangesAsync();
                }
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
        public async Task<BaseViewModel<bool>> UpdateInformation([FromBody]Step1 model)
        {
            try
            {
                var userId = User.Identity.UserID();
                var employe = _context.TblEmployee.FirstOrDefault(x => x.EmployeeLoginId == userId);
                var login = _context.TblLogin.FirstOrDefault(x => x.LoginId == userId);

                if (model.StepNumber == 1)
                {
                    login.LoginFirstName = model.FirstName;
                    login.LoginLastName = model.LastName;
                    login.LoginNationalCode = model.NationalCode;
                    login.LoginEmail = model.Email;
                    login.LoginPasswordHash = model.Password;
                    login.LoginGenderCodeId = (int)model.Gender;
                    login.LoginBirthday = model.Birthday.ToEnglishDate();

                    if (model.type == Enum_UserType.Supplier_Legal)
                    {
                        var orgname = model.infoes.FirstOrDefault(x => x.TypeCodeId == (int)Enum_Code.Organization_Name);
                        if (orgname != null)
                        {
                            var organization = await _context.TblOrganization.FirstOrDefaultAsync(x => x.OrganizationId == employe.EmployeeOrganizationId);
                            organization.OrganizationNameInformationId = (int)Enum_Code.Organization_Name;

                        }
                    }
                }
                foreach (var item in model.infoes)
                {
                    var info = await _context.TblOrganizationInformation.FirstOrDefaultAsync(x => x.OiTypeCodeId == item.TypeCodeId && x.OiOrganizationId == employe.EmployeeOrganizationId);
                    if (info == null)
                    {

                        TblOrganizationInformation tblOrganizationInformation = new TblOrganizationInformation()
                        {
                            OiIsAccept = null,
                            OiOrganizationId = employe.EmployeeOrganizationId,
                            OiText = item.Value,
                            OiTypeCodeId = item.TypeCodeId
                        };
                        _context.TblOrganizationInformation.Add(tblOrganizationInformation);

                    }
                    else
                    {
                        info.OiText = item.Value;
                    }
                }

                await _context.SaveChangesAsync();



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
        public async Task<BaseViewModel<ViewStep3>> Step3([FromForm]IFormFile[] files)
        {
            try
            {
                var userId = User.Identity.UserID();
                var organization = _context.TblEmployee.FirstOrDefault(x => x.EmployeeLoginId == userId);
                foreach (var item in files)
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
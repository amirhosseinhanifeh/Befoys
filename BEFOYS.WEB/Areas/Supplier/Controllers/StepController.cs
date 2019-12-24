using BEFOYS.Common.AppUser;
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


        [HttpPost]
        public async Task<ActionResult<BaseViewModel<object>>> GetInformation()
        {
            var user = User.Identity.UserID();
            var data = _context.TblLogin.Find(user);

            var info = await _context.TblOrganizationInformation
                .Include(x => x.OiTypeCode)
                .Include(x => x.OiOrganization)
                .Include(x => x.OiOrganization.TblEmployee)
                .Where(x => x.OiOrganization.TblEmployee.Any(y => y.EmployeeLoginId == user))
                .Select(x => new ViewOrganizationInformation { IsAccept = x.OiIsAccept, FieldName = x.OiTypeCodeId.ToString(), Value = x.OiText, isFeature = true, Reason = x.OiRejectDetails }).ToListAsync();
            List<AddressValue> address = new List<AddressValue>();

            if (data != null)
            {

                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "FirstName", Value = data.LoginFirstName, isFeature = false });
                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "LastName", Value = data.LoginLastName, isFeature = false });
                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "Email", Value = data.LoginEmail, isFeature = false });
                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "NationalCode", Value = data.LoginNationalCode, isFeature = false });
                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "Gender", Value = data.LoginGenderCodeId.ToString(), isFeature = false });
                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "Year", Value = data.LoginBirthday.GetValueOrDefault().ToPersianDate().Split('/')[0].PersianToEnglish(), isFeature = false });
                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "Month", Value = data.LoginBirthday.GetValueOrDefault().ToPersianDate().Split('/')[1].PersianToEnglish(), isFeature = false });
                info.Add(new ViewOrganizationInformation { IsAccept = true, FieldName = "Day", Value = data.LoginBirthday.GetValueOrDefault().ToPersianDate().Split('/')[2].PersianToEnglish(), isFeature = false });


                var Address = data.TblEmployee?.FirstOrDefault()?.EmployeeOrganization?.TblAddress;
                if (Address != null)
                {
                    int address_index = 0;


                    foreach (var item in Address)
                    {
                        int phone_index = 0;
                        address.Add(new AddressValue { index = item.AddressId, Address = item.AddressText, AddressIndex = $"Addresses[{address_index}].Address", StateIndex = $"Addresses[{address_index}].StateName",CityName=item.AddressCity.CityName, StateName= item.AddressCity.CityProvince.ProvinceName, CityIndex = $"Addresses[{address_index}].CityName" });
                        List<Phone> phones = new List<Phone>();
                        foreach (var item2 in item.TblPhone)
                        {

                            phones.Add(new Phone { PhoneIndex = $"Addresses[{address_index}].phones[{phone_index}].PhoneValue", PhoneValue = item2.PhoneNumber });
                            phone_index = phone_index + 1;
                            AddressValue newaddress = address.FirstOrDefault(x => x.index == item.AddressId);
                            newaddress.phones = phones.ToArray();
                        }

                        address_index = address_index + 1;

                    }
                }
            }

            return new BaseViewModel<object> { Message = "موفقیت آمیز", NotificationType = Enum_NotificationType.success, Value = new { infoes = info, Address = address } };

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
                if (model.infoes != null)
                {
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
                                OiTypeCodeId = item.TypeCodeId,

                            };
                            _context.TblOrganizationInformation.Add(tblOrganizationInformation);

                        }
                        else
                        {
                            info.OiText = item.Value;
                        }
                    }
                }
                var Data = _context.TblAddress.Where(x => x.AddressOrganizationId == employe.EmployeeOrganizationId).ToList();
                _context.TblAddress.RemoveRange(Data);
                await _context.SaveChangesAsync();

                if (model.Addresses != null)
                {
                    List<TblAddress> list = new List<TblAddress>();
                    foreach (var item in model.Addresses)
                    {
                        string iguid = item.CityName;
                        var city = _context.TblCity.FirstOrDefault(x => x.CityName == iguid);
                        TblAddress address = new TblAddress
                        {
                            AddressOrganizationId = employe.EmployeeOrganizationId,
                            AddressText = item.Address,
                            AddressIsSetGps = false,
                            AddressCityId = city.CityId,
                            AddressTypeCodeId = 1,
                        };
                        foreach (var item2 in item.phones)
                        {
                            address.TblPhone.Add(new TblPhone {
                                PhoneNumber = item2.PhoneValue,
                                PhoneAreaCodeId = 5,
                                PhoneTypeCodeId = 1,

                            
                            });
                        }
                        list.Add(address);
                    }
                    _context.TblAddress.AddRange(list);

                }
                await _context.SaveChangesAsync();
                return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool>
                {
                    Value = false,
                    Message = e.Message,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }
        #endregion
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> SetOrganizationCategory([FromBody]int[] Cats)
        {
            var userId = User.Identity.UserID();
            var employe = _context.TblEmployee.FirstOrDefault(x => x.EmployeeLoginId == userId);
            List<TblOrganizationProductCategory> list = new List<TblOrganizationProductCategory>();

            foreach (var item in Cats)
            {
                list.Add(new TblOrganizationProductCategory { OpcOrganizationId = employe.EmployeeOrganizationId, OpcIsAccept = false, OpcPcid = item });
            }
            _context.TblOrganizationProductCategory.AddRange(list);
            await _context.SaveChangesAsync();
            return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

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
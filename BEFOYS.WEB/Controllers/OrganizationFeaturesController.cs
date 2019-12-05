using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Organization;
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
    public class OrganizationFeaturesController : ControllerBase
    {
        private ServiceContext _context;

        public OrganizationFeaturesController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Post()
        {
            return Ok();
        }

        [HttpGet("{OrganizationTypeID}")]
        public async Task<ActionResult<BaseViewModel<List<ViewOrganizationFeatures>>>> Get(Guid OrganizationTypeID)
        {

            var OrType = await _context.TblOrganizationNavigator.Include(c => c.OdnOdf).Include(x => x.OdnOdf.OdfTypeCode).Where(x => x.OdnOt.OtGuid == OrganizationTypeID).ToListAsync();
            if (OrType != null)
            {
                return new BaseViewModel<List<ViewOrganizationFeatures>> { Value = OrType.Select(x => x.OdnOdf).Select(y => new ViewOrganizationFeatures(y)).ToList(), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            return new BaseViewModel<List<ViewOrganizationFeatures>> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
        }
    }
}
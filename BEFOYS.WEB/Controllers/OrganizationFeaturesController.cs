using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Organization;
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
        public async Task<ActionResult<BaseViewModel<Tbl_OrganizationDocumentFeatures>>> Post()
        {
            return Ok();
        }

        [HttpGet("{OrganizationTypeID}")]
        public async Task<ActionResult<BaseViewModel<List<ViewOrganizationFeatures>>>> Get(Guid OrganizationTypeID)
        {

            var OrType = await _context.Tbl_OrganizationDocumentNavigator.Include(c => c.OrganizationDocumentFeatures).Include(x => x.OrganizationDocumentFeatures.Code).Where(x => x.OrganizationType.OT_Guid == OrganizationTypeID).ToListAsync();
            if (OrType != null)
            {
                return new BaseViewModel<List<ViewOrganizationFeatures>> { Value = OrType.Select(x => x.OrganizationDocumentFeatures).Select(y => new ViewOrganizationFeatures(y)).ToList(), Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            return new BaseViewModel<List<ViewOrganizationFeatures>> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
        }
    }
}
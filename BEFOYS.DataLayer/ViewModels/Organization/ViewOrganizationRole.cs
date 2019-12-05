using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Organization
{
    public class ViewOrganizationRole
    {
        public int? OrId { get; set; }
        public int? OrOrid { get; set; }
        public int OrOrganizationId { get; set; }
        public string OrDisplay { get; set; }
        public bool OrCanCreateRole { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Organization
{
    public class Tbl_OrganizationType
    {
        [Key]
        public int OT_ID { get; set; }
        public Guid OT_Guid { get; set; }
        public string OT_Name { get; set; }
        public string OT_Display { get; set; }

        public ICollection<Tbl_OrganizationDocumentNavigator> OrganizationDocumentNavigators{ get; set; }
    }
}

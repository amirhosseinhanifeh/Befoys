using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Organization
{
    public class Tbl_Organization
    {
        [Key]
        public int Organization_ID { get; set; }
        public Guid Organization_GUID { get; set; }
        public Guid Organization_OTID { get; set; }
        public int? Organization_MotherOrganizationID { get; set; }
        public bool Organization_IsMotherOrganization { get; set; }
        public bool Organization_IsBan { get; set; }
        public bool Organization_IsDelete { get; set; }
        public bool Organization_IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Organization
{
    public class Tbl_OrganizationDocument
    {
        [Key]
        public int OD_ID { get; set; }
        public Guid OD_GUID { get; set; }
        public int OD_OrganizationID { get; set; }
        public int OD_DocumentID { get; set; }
    }
}

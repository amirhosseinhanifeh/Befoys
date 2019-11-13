using BEFOYS.DataLayer.Entity.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Organization
{
    public class Tbl_OrganizationInformation
    {
        [Key]
        public int OI_ID { get; set; }
        public Guid OI_Guid { get; set; } = Guid.NewGuid();
        public int OI_TypeCodeID { get; set; }
        public string OI_Text { get; set; }
        public int OI_OrganizationID { get; set; }

        [ForeignKey("OI_OrganizationID")]
        public Tbl_Organization Organization { get; set; }

        [ForeignKey("OI_TypeCodeID")]
        public Tbl_Code Code { get; set; }


    }
}

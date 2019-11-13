using BEFOYS.DataLayer.Entity.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Organization
{
    public class Tbl_OrganizationDocumentFeatures
    {
        [Key]
        public int ODF_ID { get; set; }
        public Guid ODF_Guid { get; set; }
        public int ODF_TypeCodeID { get; set; }
        public bool ODF_Mandatory { get; set; }

        [ForeignKey("ODF_TypeCodeID")]
        public Tbl_Code Code { get; set; }
        public ICollection<Tbl_OrganizationDocumentNavigator> OrganizationDocumentNavigators { get; set; }
    }
}

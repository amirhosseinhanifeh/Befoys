using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Organization
{
    public class Tbl_OrganizationDocumentNavigator
    {
        [Key]
        public int ODN_ID { get; set; }
        public Guid ODN_Guid { get; set; }
        public int ODN_ODFID { get; set; }
        public int ODN_OTID { get; set; }

        [ForeignKey("ODN_ODFID")]
        public Tbl_OrganizationDocumentFeatures OrganizationDocumentFeatures { get; set; }

        [ForeignKey("ODN_OTID")]
        public Tbl_OrganizationType OrganizationType { get; set; }
    }
}

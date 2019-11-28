using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationDocumentNavigator")]
    public partial class TblOrganizationDocumentNavigator
    {
        [Key]
        [Column("ODN_ID")]
        public int OdnId { get; set; }
        [Column("ODN_Guid")]
        public Guid OdnGuid { get; set; }
        [Column("ODN_ODFID")]
        public int OdnOdfid { get; set; }
        [Column("ODN_OTID")]
        public int OdnOtid { get; set; }

        [ForeignKey(nameof(OdnOdfid))]
        [InverseProperty(nameof(TblOrganizationDocumentFeatures.TblOrganizationDocumentNavigator))]
        public virtual TblOrganizationDocumentFeatures OdnOdf { get; set; }
        [ForeignKey(nameof(OdnOtid))]
        [InverseProperty(nameof(TblOrganizationType.TblOrganizationDocumentNavigator))]
        public virtual TblOrganizationType OdnOt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationNavigator")]
    public partial class TblOrganizationNavigator
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
        [InverseProperty(nameof(TblOrganizationFeatures.TblOrganizationNavigator))]
        public virtual TblOrganizationFeatures OdnOdf { get; set; }
        [ForeignKey(nameof(OdnOtid))]
        [InverseProperty(nameof(TblOrganizationType.TblOrganizationNavigator))]
        public virtual TblOrganizationType OdnOt { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationFeatures")]
    public partial class TblOrganizationFeatures
    {
        public TblOrganizationFeatures()
        {
            TblOrganizationNavigator = new HashSet<TblOrganizationNavigator>();
        }

        [Key]
        [Column("ODF_ID")]
        public int OdfId { get; set; }
        [Column("ODF_Guid")]
        public Guid OdfGuid { get; set; }
        [Column("ODF_TypeCodeID")]
        public int OdfTypeCodeId { get; set; }
        [Column("ODF_KindCodeID")]
        public int? OdfKindCodeId { get; set; }
        [Column("ODF_Mandatory")]
        public bool OdfMandatory { get; set; }

        [ForeignKey(nameof(OdfKindCodeId))]
        [InverseProperty(nameof(TblCode.TblOrganizationFeaturesOdfKindCode))]
        public virtual TblCode OdfKindCode { get; set; }
        [ForeignKey(nameof(OdfTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblOrganizationFeaturesOdfTypeCode))]
        public virtual TblCode OdfTypeCode { get; set; }
        [InverseProperty("OdnOdf")]
        public virtual ICollection<TblOrganizationNavigator> TblOrganizationNavigator { get; set; }
    }
}

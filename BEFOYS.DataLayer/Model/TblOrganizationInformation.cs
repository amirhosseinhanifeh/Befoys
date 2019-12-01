using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_OrganizationInformation")]
    public partial class TblOrganizationInformation
    {
        [Key]
        [Column("OI_ID")]
        public int OiId { get; set; }
        [Column("OI_Guid")]
        public Guid? OiGuid { get; set; }
        [Column("OI_TypeCodeID")]
        public int? OiTypeCodeId { get; set; }
        [Column("OI_Text", TypeName = "ntext")]
        public string OiText { get; set; }
        [Column("OI_OrganizationID")]
        public int? OiOrganizationId { get; set; }
        [Column("OI_IsAccept")]
        public bool OiIsAccept { get; set; }
        [ForeignKey(nameof(OiOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblOrganizationInformation))]
        public virtual TblOrganization OiOrganization { get; set; }
        [ForeignKey(nameof(OiTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblOrganizationInformation))]
        public virtual TblCode OiTypeCode { get; set; }
    }
}

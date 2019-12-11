using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Guarantee")]
    public partial class TblGuarantee
    {
        public TblGuarantee()
        {
            TblProductOrganization = new HashSet<TblProductOrganization>();
        }

        [Key]
        [Column("Guarantee_ID")]
        public int GuaranteeId { get; set; }
        [Column("Guarantee_Guid")]
        public Guid GuaranteeGuid { get; set; }
        [Column("Guarantee_LogoDocumentID")]
        public int? GuaranteeLogoDocumentId { get; set; }
        [Required]
        [Column("Guarantee_Name")]
        [StringLength(50)]
        public string GuaranteeName { get; set; }
        [Column("Guarantee_IsVerify")]
        public bool GuaranteeIsVerify { get; set; }

        [InverseProperty("PoGuarantee")]
        public virtual ICollection<TblProductOrganization> TblProductOrganization { get; set; }
    }
}

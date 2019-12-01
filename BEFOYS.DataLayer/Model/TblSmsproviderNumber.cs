using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_SMSProviderNumber")]
    public partial class TblSmsproviderNumber
    {
        [Key]
        [Column("SPN_ID")]
        public int SpnId { get; set; }
        [Column("SPN_Guid")]
        public Guid SpnGuid { get; set; }
        [Column("SPN_SPCID")]
        public int SpnSpcid { get; set; }
        [Required]
        [Column("SPN_Number")]
        [StringLength(128)]
        public string SpnNumber { get; set; }
        [Column("SPN_CreationDate")]
        public DateTime SpnCreationDate { get; set; }
        [Column("SPN_ModifiedDate")]
        public DateTime SpnModifiedDate { get; set; }
        [Column("SPN_IsDelete")]
        public bool SpnIsDelete { get; set; }

        [ForeignKey(nameof(SpnSpcid))]
        [InverseProperty(nameof(TblSmsproviderConfiguration.TblSmsproviderNumber))]
        public virtual TblSmsproviderConfiguration SpnSpc { get; set; }
    }
}

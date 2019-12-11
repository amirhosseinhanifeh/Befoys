using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCustomRequestFormValue")]
    public partial class TblProductCustomRequestFormValue
    {
        [Key]
        [Column("PCRFV_ID")]
        public int PcrfvId { get; set; }
        [Column("PCRFV_Guid")]
        public Guid PcrfvGuid { get; set; }
        [Column("PCRFV_PCRID")]
        public int PcrfvPcrid { get; set; }
        [Column("PCRFV_PCOFID")]
        public int PcrfvPcofid { get; set; }
        [Required]
        [Column("PCRFV_Value")]
        public string PcrfvValue { get; set; }

        [ForeignKey(nameof(PcrfvPcofid))]
        [InverseProperty(nameof(TblProductCustomOrganizationForm.TblProductCustomRequestFormValue))]
        public virtual TblProductCustomOrganizationForm PcrfvPcof { get; set; }
        [ForeignKey(nameof(PcrfvPcrid))]
        [InverseProperty(nameof(TblProductCustomRequest.TblProductCustomRequestFormValue))]
        public virtual TblProductCustomRequest PcrfvPcr { get; set; }
    }
}

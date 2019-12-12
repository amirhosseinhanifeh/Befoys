using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCustomOrganizationForm")]
    public partial class TblProductCustomOrganizationForm
    {
        public TblProductCustomOrganizationForm()
        {
            TblProductCustomRequestFormValue = new HashSet<TblProductCustomRequestFormValue>();
        }

        [Key]
        [Column("PCOF_ID")]
        public int PcofId { get; set; }
        [Column("PCOF_Guid")]
        public Guid PcofGuid { get; set; }
        [Column("PCOF_POID")]
        public int PcofPoid { get; set; }
        [Column("PCOF_TypeCodeID")]
        public int PcofTypeCodeId { get; set; }
        [Required]
        [Column("PCOF_Display")]
        public string PcofDisplay { get; set; }

        [ForeignKey(nameof(PcofPoid))]
        [InverseProperty(nameof(TblProductOrganization.TblProductCustomOrganizationForm))]
        public virtual TblProductOrganization PcofPo { get; set; }
        [InverseProperty("PcrfvPcof")]
        public virtual ICollection<TblProductCustomRequestFormValue> TblProductCustomRequestFormValue { get; set; }
    }
}

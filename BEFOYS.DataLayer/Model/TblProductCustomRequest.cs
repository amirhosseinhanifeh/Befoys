using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCustomRequest")]
    public partial class TblProductCustomRequest
    {
        public TblProductCustomRequest()
        {
            TblProductCustomRequestAttachment = new HashSet<TblProductCustomRequestAttachment>();
            TblProductCustomRequestFormValue = new HashSet<TblProductCustomRequestFormValue>();
            TblProductCustomRequestMessage = new HashSet<TblProductCustomRequestMessage>();
        }

        [Key]
        [Column("PCR_ID")]
        public int PcrId { get; set; }
        [Column("PCR_Guid")]
        public Guid PcrGuid { get; set; }
        [Column("PCR_OrganizitonID")]
        public int PcrOrganizitonId { get; set; }
        [Column("PCR_POID")]
        public int PcrPoid { get; set; }
        [Column("PCR_Price")]
        public int PcrPrice { get; set; }
        [Column("PCR_Count")]
        public int PcrCount { get; set; }
        [Column("PCR_RequestTime")]
        public DateTime PcrRequestTime { get; set; }
        [Column("PCR_AnswerTime")]
        public DateTime PcrAnswerTime { get; set; }
        [Required]
        [Column("PCR_Description")]
        public string PcrDescription { get; set; }
        [Column("PCR_HasForm")]
        public bool PcrHasForm { get; set; }

        [ForeignKey(nameof(PcrOrganizitonId))]
        [InverseProperty(nameof(TblOrganization.TblProductCustomRequest))]
        public virtual TblOrganization PcrOrganiziton { get; set; }
        [ForeignKey(nameof(PcrPoid))]
        [InverseProperty(nameof(TblProductOrganization.TblProductCustomRequest))]
        public virtual TblProductOrganization PcrPo { get; set; }
        [InverseProperty("PcraPcr")]
        public virtual ICollection<TblProductCustomRequestAttachment> TblProductCustomRequestAttachment { get; set; }
        [InverseProperty("PcrfvPcr")]
        public virtual ICollection<TblProductCustomRequestFormValue> TblProductCustomRequestFormValue { get; set; }
        [InverseProperty("PcrmPcr")]
        public virtual ICollection<TblProductCustomRequestMessage> TblProductCustomRequestMessage { get; set; }
    }
}

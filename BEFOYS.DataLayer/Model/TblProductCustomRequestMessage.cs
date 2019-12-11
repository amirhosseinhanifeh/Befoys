using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCustomRequestMessage")]
    public partial class TblProductCustomRequestMessage
    {
        [Key]
        [Column("PCRM_ID")]
        public int PcrmId { get; set; }
        [Column("PCRM_Guid")]
        public Guid PcrmGuid { get; set; }
        [Required]
        [Column("PCRM_Message")]
        public string PcrmMessage { get; set; }
        [Column("PCRM_LoginID")]
        public int PcrmLoginId { get; set; }
        [Column("PCRM_PCRID")]
        public int PcrmPcrid { get; set; }
        [Column("PCRM_DocumentID")]
        public int PcrmDocumentId { get; set; }

        [ForeignKey(nameof(PcrmDocumentId))]
        [InverseProperty(nameof(TblDocument.TblProductCustomRequestMessage))]
        public virtual TblDocument PcrmDocument { get; set; }
        [ForeignKey(nameof(PcrmPcrid))]
        [InverseProperty(nameof(TblProductCustomRequest.TblProductCustomRequestMessage))]
        public virtual TblProductCustomRequest PcrmPcr { get; set; }
    }
}

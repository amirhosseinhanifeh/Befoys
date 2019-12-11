using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_ProductCustomRequestAttachment")]
    public partial class TblProductCustomRequestAttachment
    {
        [Column("PCRA_ID")]
        public int PcraId { get; set; }
        [Column("PCRA_Guid")]
        public Guid PcraGuid { get; set; }
        [Column("PCRA_DocumentID")]
        public int PcraDocumentId { get; set; }
        [Column("PCRA_PCRID")]
        public int PcraPcrid { get; set; }

        [ForeignKey(nameof(PcraPcrid))]
        [InverseProperty(nameof(TblProductCustomRequest.TblProductCustomRequestAttachment))]
        public virtual TblProductCustomRequest PcraPcr { get; set; }
    }
}

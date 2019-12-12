using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_TicketAnswer")]
    public partial class TblTicketAnswer
    {
        [Key]
        [Column("TA_ID")]
        public int TaId { get; set; }
        [Column("TA_GUID")]
        public Guid? TaGuid { get; set; }
        [Column("TA_TicketID")]
        public int TaTicketId { get; set; }
        [Required]
        [Column("TA_Message")]
        public string TaMessage { get; set; }
        [Column("TA_SenderLoginID")]
        public int TaSenderLoginId { get; set; }
        [Column("TA_CreateDate", TypeName = "datetime")]
        public DateTime TaCreateDate { get; set; }

        [ForeignKey(nameof(TaTicketId))]
        [InverseProperty(nameof(TblTicket.TblTicketAnswer))]
        public virtual TblTicket TaTicket { get; set; }
    }
}

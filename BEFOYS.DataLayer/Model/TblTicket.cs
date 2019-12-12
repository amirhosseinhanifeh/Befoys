using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Ticket")]
    public partial class TblTicket
    {
        public TblTicket()
        {
            TblTicketAnswer = new HashSet<TblTicketAnswer>();
        }

        [Key]
        [Column("Ticket_ID")]
        public int TicketId { get; set; }
        [Column("Ticket_GUID")]
        public Guid? TicketGuid { get; set; }
        [Column("Ticket_SenderLoginID")]
        public int? TicketSenderLoginId { get; set; }
        [Column("Ticket_ReciverLoginID")]
        public int? TicketReciverLoginId { get; set; }
        [Column("Ticket_PriorityCodeID")]
        public int? TicketPriorityCodeId { get; set; }
        [Column("Ticket_Title")]
        public string TicketTitle { get; set; }
        [Column("Ticket_Text")]
        public string TicketText { get; set; }

        [ForeignKey(nameof(TicketPriorityCodeId))]
        [InverseProperty(nameof(TblCode.TblTicket))]
        public virtual TblCode TicketPriorityCode { get; set; }
        [ForeignKey(nameof(TicketReciverLoginId))]
        [InverseProperty(nameof(TblLogin.TblTicketTicketReciverLogin))]
        public virtual TblLogin TicketReciverLogin { get; set; }
        [ForeignKey(nameof(TicketSenderLoginId))]
        [InverseProperty(nameof(TblLogin.TblTicketTicketSenderLogin))]
        public virtual TblLogin TicketSenderLogin { get; set; }
        [InverseProperty("TaTicket")]
        public virtual ICollection<TblTicketAnswer> TblTicketAnswer { get; set; }
    }
}

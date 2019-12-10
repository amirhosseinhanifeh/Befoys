using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Message")]
    public partial class TblMessage
    {
        [Key]
        [Column("Message_ID")]
        public int MessageId { get; set; }
        [Column("Message_Guid")]
        public Guid MessageGuid { get; set; }
        [Column("Message_SenderLoginID")]
        public int MessageSenderLoginId { get; set; }
        [Column("Message_ReceiverLoginID")]
        public int? MessageReceiverLoginId { get; set; }
        [Column("Message_ReceiverOrganizationID")]
        public int MessageReceiverOrganizationId { get; set; }
        [Column("Message_TypeCodeID")]
        public int MessageTypeCodeId { get; set; }
        [Column("Message_PriorityCodeID")]
        public int MessagePriorityCodeId { get; set; }
        [Required]
        [Column("Message_Title")]
        public string MessageTitle { get; set; }
        [Required]
        [Column("Message_Text")]
        public string MessageText { get; set; }

        [ForeignKey(nameof(MessagePriorityCodeId))]
        [InverseProperty(nameof(TblCode.TblMessageMessagePriorityCode))]
        public virtual TblCode MessagePriorityCode { get; set; }
        [ForeignKey(nameof(MessageReceiverLoginId))]
        [InverseProperty(nameof(TblLogin.TblMessageMessageReceiverLogin))]
        public virtual TblLogin MessageReceiverLogin { get; set; }
        [ForeignKey(nameof(MessageReceiverOrganizationId))]
        [InverseProperty(nameof(TblOrganization.TblMessage))]
        public virtual TblOrganization MessageReceiverOrganization { get; set; }
        [ForeignKey(nameof(MessageSenderLoginId))]
        [InverseProperty(nameof(TblLogin.TblMessageMessageSenderLogin))]
        public virtual TblLogin MessageSenderLogin { get; set; }
        [ForeignKey(nameof(MessageTypeCodeId))]
        [InverseProperty(nameof(TblCode.TblMessageMessageTypeCode))]
        public virtual TblCode MessageTypeCode { get; set; }
    }
}

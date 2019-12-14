using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_SMSResponse")]
    public partial class TblSmsresponse
    {
        [Key]
        [Column("SMS_ID")]
        public int SmsId { get; set; }
        [Column("SMS_Guid")]
        public Guid SmsGuid { get; set; }
        [Column("SMS_Status")]
        public int SmsStatus { get; set; }
        [Required]
        [Column("SMS_StatusText")]
        public string SmsStatusText { get; set; }
        [Column("SMS_STID")]
        public int? SmsStid { get; set; }
        [Required]
        [Column("SMS_Message")]
        public string SmsMessage { get; set; }
        [Column("SMS_Token")]
        [StringLength(128)]
        public string SmsToken { get; set; }
        [Column("SMS_Token1")]
        [StringLength(128)]
        public string SmsToken1 { get; set; }
        [Column("SMS_Token2")]
        [StringLength(128)]
        public string SmsToken2 { get; set; }
        [Required]
        [Column("SMS_Sender")]
        [StringLength(128)]
        public string SmsSender { get; set; }
        [Required]
        [Column("SMS_Receptor")]
        [StringLength(128)]
        public string SmsReceptor { get; set; }
        [Column("SMS_Date")]
        public DateTime SmsDate { get; set; }
        [Column("SMS_Cost")]
        public int SmsCost { get; set; }
        [Column("SMS_CreationDate")]
        public DateTime SmsCreationDate { get; set; }
        [Column("SMS_ModifiedDate")]
        public DateTime SmsModifiedDate { get; set; }
        [Column("SMS_IsDelete")]
        public bool SmsIsDelete { get; set; }
        [Column("SMS_LoginID")]
        public int? SmsLoginId { get; set; }

        [ForeignKey(nameof(SmsLoginId))]
        [InverseProperty(nameof(TblLogin.TblSmsresponse))]
        public virtual TblLogin SmsLogin { get; set; }
        [ForeignKey(nameof(SmsStid))]
        [InverseProperty(nameof(TblSmstemplate.TblSmsresponse))]
        public virtual TblSmstemplate SmsSt { get; set; }
    }
}

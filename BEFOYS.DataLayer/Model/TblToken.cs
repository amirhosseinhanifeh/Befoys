using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Token")]
    public partial class TblToken
    {
        [Key]
        [Column("Token_ID")]
        public int TokenId { get; set; }
        [Column("Token_GUID")]
        public Guid TokenGuid { get; set; }
        [Column("Token_TypeCodeID")]
        public int? TokenTypeCodeId { get; set; }
        [Column("Token_Start")]
        public DateTime TokenStart { get; set; }
        [Column("Token_EXP")]
        public DateTime TokenExp { get; set; }
        [Required]
        [Column("Token_Hush")]
        [StringLength(50)]
        public string TokenHush { get; set; }
        [Column("Token_LoginID")]
        public int TokenLoginId { get; set; }

        [ForeignKey(nameof(TokenLoginId))]
        [InverseProperty(nameof(TblLogin.TblToken))]
        public virtual TblLogin TokenLogin { get; set; }
    }
}

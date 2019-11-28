using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Login")]
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblEmployee = new HashSet<TblEmployee>();
            TblToken = new HashSet<TblToken>();
        }

        [Key]
        [Column("Login_ID")]
        public int LoginId { get; set; }
        [Column("Login_Guid")]
        public Guid LoginGuid { get; set; }
        [Column("Login_PictureDocumentID")]
        public int? LoginPictureDocumentId { get; set; }
        [Column("Login_PasswordHash")]
        public string LoginPasswordHash { get; set; }
        [Column("Login_PasswordSalt")]
        public string LoginPasswordSalt { get; set; }
        [Column("Login_FirstName")]
        [StringLength(100)]
        public string LoginFirstName { get; set; }
        [Column("Login_LastName")]
        [StringLength(100)]
        public string LoginLastName { get; set; }
        [Column("Login_Email")]
        [StringLength(100)]
        public string LoginEmail { get; set; }
        [Required]
        [Column("Login_Mobile")]
        [StringLength(100)]
        public string LoginMobile { get; set; }
        [Column("Login_IsBan")]
        public bool LoginIsBan { get; set; }
        [Column("Login_IsDelete")]
        public bool LoginIsDelete { get; set; }
        [Column("Login_IsRegister")]
        public bool LoginIsRegister { get; set; }
        [Column("Login_CreateDate")]
        public DateTime LoginCreateDate { get; set; }
        [Column("Login_ModifyDate")]
        public DateTime LoginModifyDate { get; set; }

        [ForeignKey(nameof(LoginPictureDocumentId))]
        [InverseProperty(nameof(TblDocument.TblLogin))]
        public virtual TblDocument LoginPictureDocument { get; set; }
        [InverseProperty("EmployeeLogin")]
        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
        [InverseProperty("TokenLogin")]
        public virtual ICollection<TblToken> TblToken { get; set; }
    }
}

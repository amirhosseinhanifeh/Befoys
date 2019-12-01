using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_SMSProviderConfiguration")]
    public partial class TblSmsproviderConfiguration
    {
        public TblSmsproviderConfiguration()
        {
            TblSmsproviderNumber = new HashSet<TblSmsproviderNumber>();
            TblSmssetting = new HashSet<TblSmssetting>();
        }

        [Key]
        [Column("SPC_ID")]
        public int SpcId { get; set; }
        [Column("SPC_Guid")]
        public Guid? SpcGuid { get; set; }
        [Required]
        [Column("SPC_Username")]
        [StringLength(128)]
        public string SpcUsername { get; set; }
        [Required]
        [Column("SPC_Password")]
        [StringLength(128)]
        public string SpcPassword { get; set; }
        [Required]
        [Column("SPC_ApiKey")]
        [StringLength(128)]
        public string SpcApiKey { get; set; }
        [Column("SPC_CreationDate")]
        public DateTime SpcCreationDate { get; set; }
        [Column("SPC_ModifiedDate")]
        public DateTime SpcModifiedDate { get; set; }
        [Column("SPC_IsDelete")]
        public bool SpcIsDelete { get; set; }

        [InverseProperty("SpnSpc")]
        public virtual ICollection<TblSmsproviderNumber> TblSmsproviderNumber { get; set; }
        [InverseProperty("SsSpc")]
        public virtual ICollection<TblSmssetting> TblSmssetting { get; set; }
    }
}

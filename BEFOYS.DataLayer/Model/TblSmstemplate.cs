using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_SMSTemplate")]
    public partial class TblSmstemplate
    {
        public TblSmstemplate()
        {
            TblSmsresponse = new HashSet<TblSmsresponse>();
            TblSmssetting = new HashSet<TblSmssetting>();
        }

        [Key]
        [Column("ST_ID")]
        public int StId { get; set; }
        [Column("ST_Guid")]
        public Guid StGuid { get; set; }
        [Required]
        [Column("ST_Name")]
        [StringLength(128)]
        public string StName { get; set; }
        [Column("ST_CreationDate")]
        public DateTime StCreationDate { get; set; }
        [Column("ST_ModifiedDate")]
        public DateTime StModifiedDate { get; set; }
        [Column("ST_IsDelete")]
        public bool StIsDelete { get; set; }

        [InverseProperty("SmsSt")]
        public virtual ICollection<TblSmsresponse> TblSmsresponse { get; set; }
        [InverseProperty("SsSt")]
        public virtual ICollection<TblSmssetting> TblSmssetting { get; set; }
    }
}

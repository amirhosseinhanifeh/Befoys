using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_EmployeeRegistrationCode")]
    public partial class TblEmployeeRegistrationCode
    {
        [Key]
        [Column("ERC_ID")]
        public int ErcId { get; set; }
        [Column("ERC_Guid")]
        public Guid ErcGuid { get; set; }
        [Column("ERC_EmployeeID")]
        public int ErcEmployeeId { get; set; }
        [Required]
        [Column("SURC_Code")]
        [StringLength(50)]
        public string SurcCode { get; set; }
        [Column("ERC_Start")]
        public DateTime ErcStart { get; set; }
        [Column("ERC_IsExpired")]
        public bool ErcIsExpired { get; set; }

        [ForeignKey(nameof(ErcEmployeeId))]
        [InverseProperty(nameof(TblEmployee.TblEmployeeRegistrationCode))]
        public virtual TblEmployee ErcEmployee { get; set; }
    }
}

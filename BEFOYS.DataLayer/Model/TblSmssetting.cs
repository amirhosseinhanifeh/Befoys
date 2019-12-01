using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_SMSSetting")]
    public partial class TblSmssetting
    {
        [Key]
        [Column("SS_ID")]
        public int SsId { get; set; }
        [Column("SS_Guid")]
        public Guid SsGuid { get; set; }
        [Column("SS_SPCID")]
        public int SsSpcid { get; set; }
        [Column("SS_STID")]
        public int SsStid { get; set; }
        [Column("SS_CreationDate")]
        public DateTime SsCreationDate { get; set; }
        [Column("SS_ModifiedDate")]
        public DateTime SsModifiedDate { get; set; }
        [Column("SS_IsDelete")]
        public bool SsIsDelete { get; set; }

        [ForeignKey(nameof(SsSpcid))]
        [InverseProperty(nameof(TblSmsproviderConfiguration.TblSmssetting))]
        public virtual TblSmsproviderConfiguration SsSpc { get; set; }
        [ForeignKey(nameof(SsStid))]
        [InverseProperty(nameof(TblSmstemplate.TblSmssetting))]
        public virtual TblSmstemplate SsSt { get; set; }
    }
}

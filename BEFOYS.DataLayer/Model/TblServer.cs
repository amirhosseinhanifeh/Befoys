using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEFOYS.DataLayer.Model
{
    [Table("Tbl_Server")]
    public partial class TblServer
    {
        public TblServer()
        {
            TblDocument = new HashSet<TblDocument>();
        }

        [Key]
        [Column("Server_ID")]
        public int ServerId { get; set; }
        [Column("Server_Guid")]
        public Guid ServerGuid { get; set; }
        [Required]
        [Column("Server_IPAddress")]
        [StringLength(50)]
        public string ServerIpaddress { get; set; }
        [Required]
        [Column("Server_Name")]
        [StringLength(50)]
        public string ServerName { get; set; }
        [Required]
        [Column("Server_Display")]
        [StringLength(50)]
        public string ServerDisplay { get; set; }
        [Required]
        [Column("Server_FilePath")]
        public string ServerFilePath { get; set; }
        [Column("Server_IsMain")]
        public bool ServerIsMain { get; set; }
        [Column("Server_IsActive")]
        public bool ServerIsActive { get; set; }

        [InverseProperty("DocumentServer")]
        public virtual ICollection<TblDocument> TblDocument { get; set; }
    }
}

using BEFOYS.DataLayer.Entity.Code;
using BEFOYS.DataLayer.Entity.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Supplier
{
    public class Tbl_SupplierDocument
    {
        [Key]
        public int SD_ID { get; set; }
        public Guid SD_GUID { get; set; }
        public int SD_TypeCodeID { get; set; }
        public int SD_SupplierID { get; set; }
        public int SD_DocumentID { get; set; }

        [ForeignKey("SD_SupplierID")]
        public Tbl_Supplier Supplier { get; set; }

        [ForeignKey("SD_TypeCodeID")]
        public Tbl_Code Code { get; set; }

        [ForeignKey("SD_DocumentID")]
        public Tbl_Document Document { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEFOYS.DataLayer.Entity.Document
{
    public class Tbl_Document
    {
        [Key]
        public int Document_ID { get; set; }
        public Guid Document_GUID { get; set; }

    }
}

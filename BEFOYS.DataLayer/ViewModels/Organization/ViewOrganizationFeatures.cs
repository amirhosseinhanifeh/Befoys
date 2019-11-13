using BEFOYS.DataLayer.Entity.Organization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Organization
{
    public class ViewOrganizationFeatures
    {
        public int ODF_ID { get; set; }
        public Guid ODF_Guid { get; set; }
        public int ODF_TypeCodeID { get; set; }
        public string ODF_CodeName { get; set; }
        public string ODF_CodeDisplay { get; set; }
        public bool ODF_Mandatory { get; set; }
        public ViewOrganizationFeatures(Tbl_OrganizationDocumentFeatures model)
        {
            ODF_ID = model.ODF_ID;
            ODF_Guid = model.ODF_Guid;
            ODF_Mandatory = model.ODF_Mandatory;
            ODF_CodeName = model.Code.Code_Name;
            ODF_CodeDisplay = model.Code.Code_Display;

        }
    }
}

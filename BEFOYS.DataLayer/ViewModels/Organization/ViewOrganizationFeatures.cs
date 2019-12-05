using BEFOYS.DataLayer.Model;
using System;

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
        public ViewOrganizationFeatures(TblOrganizationFeatures model)
        {
            ODF_ID = model.OdfId;
            ODF_Guid = model.OdfGuid;
            ODF_Mandatory = model.OdfMandatory;
            ODF_CodeName = model.OdfKindCode.CodeName;
            ODF_CodeDisplay = model.OdfKindCode.CodeDisplay;

        }
    }
}

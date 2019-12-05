using BEFOYS.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Organization
{
    public class ViewOrganizationInformation
    {
        public string FieldName { get; set; }
        public string FieldDisplay { get; set; }
        public int? TypeCodeId { get; set; }
        public string Value { get; set; }
        public int? OrganizationId { get; set; }
        public bool? IsAccept { get; set; }
        public ViewOrganizationInformation(TblOrganizationInformation model)
        {
            FieldName = model.OiTypeCode.CodeName;
            FieldDisplay = model.OiTypeCode.CodeDisplay;
            TypeCodeId = model.OiTypeCodeId;
            Value = model.OiText;
            OrganizationId = model.OiOrganizationId;
            IsAccept = model.OiIsAccept;
        }
    }
}

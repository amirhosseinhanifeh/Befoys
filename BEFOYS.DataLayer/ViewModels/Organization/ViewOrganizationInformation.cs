using BEFOYS.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BEFOYS.DataLayer.ViewModels.Organization
{
    public class ViewOrganizationInformation
    {
        public bool isFeature { get; set; }
        [JsonIgnore]
        public string FieldName { get; set; }
        public string TypeCodeId
        {
            get
            {
                if (isFeature)
                {
                    return $"infoes[{FieldName}].TypeCodeId";
                }
                else
                {
                   return FieldName;

                }
            }
            set
            {
            }
        }
        public string Value { get; set; }
        public bool? IsAccept { get; set; }
        public string Reason { get; set; }
    }
}

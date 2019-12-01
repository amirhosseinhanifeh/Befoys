using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.DataLayer.ViewModels.Employee
{
    public class ViewEmployee
    {
        public int EmployeeId { get; set; }
        public Guid EmployeeGuid { get; set; }
        public int? EmployeeLoginId { get; set; }
        public int EmployeeOrganizationId { get; set; }
        public int EmployeeWalletSize { get; set; }
        public bool EmployeeIsAgent { get; set; }
        public int EmployeeOrid { get; set; }
        
    }
}

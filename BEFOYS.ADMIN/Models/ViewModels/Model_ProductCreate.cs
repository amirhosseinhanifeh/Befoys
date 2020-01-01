using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFOYS.ADMIN.Models
{
    public class Model_ProductCreate
    {
        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public int LoginId { get; set; }

        public int OrganizationId { get; set; }

        public string Name { get; set; }
    }
}

using BEFOYS.Common.Converts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;


namespace BEFOYS.ADMIN.Classes
{
    public static class UserContext
    {
        public static string GetByUserId(this IIdentity identity, Microsoft.AspNetCore.Http.HttpContext context)
        {
            return context.Request.Cookies["token"];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.Common.Converts
{
    public static class BaseConvert
    {
        public static int ToInt(this string value)
        {
            int id=0;
            if(int.TryParse(value,out id))
            {
                return id;
            }
            return id;
        }
    }
}

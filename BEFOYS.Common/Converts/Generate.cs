using System;

namespace BEFOYS.Common.Converts
{
    public class Generate
    {
        public static string GenerateCode(int count = 4)
        {
            string Code = "";
            var r = new Random();
            for (int i = 0; i < count; i++)
            {
                Code += i.ToString();
            }
            return Code;
        }
    }
}

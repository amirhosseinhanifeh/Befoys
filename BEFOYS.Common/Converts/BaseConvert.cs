using System;
using System.Collections.Generic;
using System.Linq;
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
        public static Guid ToGuid(this string value)
        {
            Guid id = Guid.Empty;
            if (Guid.TryParse(value, out id))
            {
                return id;
            }
            return id;
        }
        public static string PersianToEnglish(this string persianStr)
        {
            Dictionary<string, string> LettersDictionary = new Dictionary<string, string>
            {
                ["۰"] = "0",
                ["۱"] = "1",
                ["۲"] = "2",
                ["۳"] = "3",
                ["۴"] = "4",
                ["۵"] = "5",
                ["۶"] = "6",
                ["۷"] = "7",
                ["۸"] = "8",
                ["۹"] = "9"
            };
            return LettersDictionary.Aggregate(persianStr, (current, item) =>
                         current.Replace(item.Key, item.Value));
        }
    }
}

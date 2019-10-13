using MD.PersianDateTime.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BEFOYS.Common.Converts
{
    public static class DateConvert
    {
        public static string ToPersianDate(this DateTime date)
        {
            return new PersianDateTime(date).ToShortDateString();
        }
        public static DateTime ToEnglishDate(this DateTime date)
        {
            return new PersianDateTime(date).ToDateTime();
        }
        //public static string toPersianNumber(this string input)
        //{
        //    string[] persian = new string[10] { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };

        //    for (int j = 0; j < persian.Length; j++)
        //        input = input.Replace(persian[j], j.ToString());

        //    return input;
        //}
        public static string ToPersianDigits(this string persianStr)
        {
            Dictionary<string, string> LettersDictionary = new Dictionary<string, string>
            {
                ["0"] = "۰",
                ["1"] = "۱",
                ["2"] = "۲",
                ["3"] = "۳",
                ["4"] = "۴",
                ["5"] = "۵",
                ["6"] = "۶",
                ["7"] = "۷",
                ["8"] = "۸",
                ["9"] = "۹"
            };
            return LettersDictionary.Aggregate(persianStr, (current, item) =>
                         current.Replace(item.Key, item.Value));
        }
        public static string ToEnglishDigits(this string persianStr)
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

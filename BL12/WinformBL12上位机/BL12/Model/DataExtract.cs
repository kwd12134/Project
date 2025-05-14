using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL12.Model
{
   public class DataExtract
    {
        public static string ExtractNumber(string input)
        {
            // 正则表达式匹配字符串中的数字部分
            Match match = Regex.Match(input, @"\d+");

            // 如果找到匹配的数字，返回该数字字符串，否则返回空字符串
            return match.Success ? match.Value : string.Empty;
        }
    }
}

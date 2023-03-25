using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Util
{
    public class StringUtil
    {
        public static string SubstringFromTo(string str, string start, string end)
        {
            int startIndex = str.IndexOf(start);
            int endIndex = str.IndexOf(end, startIndex + start.Length);
            if (startIndex == -1 || endIndex == -1)
            {
                return "";
            }
            int length = endIndex - startIndex - start.Length;
            return str.Substring(startIndex + start.Length, length);
        }
    }
}

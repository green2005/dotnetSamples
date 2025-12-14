using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class SBVTest
    {
        public string GetSB(int i)
        {
            var sb = new ValueStringBuilder(1000);
            string s2 = "ddffgg";
            for (int j = 0; j < i; j++)
            {
                sb.Append($"some{j}Stringsome{s2}StringsomeStringsomeString{j}");
            }
            return sb.ToString();
        }
         
        public string GetSB2(int i)
        {
            var sb = new StringBuilder(1000);
            string s2 = "ddffgg";
            for (int j = 0; j < i; j++)
            {
                sb.AppendFormat("some{0}Stringsome{1}StringsomeStringsomeString{0}", j, s2);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}

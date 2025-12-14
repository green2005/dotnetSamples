using ServiceStack.Text;
using System.Text;

namespace ConsoleApp3
{
    class SBTest
    {
        public String GetSB(int i)
        {
            var sb = new StringBuilder();
            string s2 = "ddffgg";
            for (int j = 0; j < i; j++)
            {
                sb.AppendLine($"some{j}Stringsome{s2}StringsomeStringsomeString{j}");
            }
            return sb.ToString();
        } 
    }
}

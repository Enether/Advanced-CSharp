

using System.Text;

namespace _01.ExtendTheStringBuilderClass
{
    public static class StringBuilderExtensions
    {
        public static string Substring(this StringBuilder sb, int startIndex, int count)
        {
            StringBuilder substring = new StringBuilder();
            for (int i = startIndex; i < startIndex+count; i++)
            {
                substring.Append(sb[i]);
            }
            return substring.ToString();
        }
    }
}

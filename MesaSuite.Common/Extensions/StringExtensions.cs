using System;
using System.Text;

namespace MesaSuite.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }

        public static string ToDisplayName(this string source)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < source.Length; i++)
            {
                if (i == 0)
                {
                    builder.Append(source[i]);
                    continue;
                }

                char character = source[i];
                if (!Char.IsWhiteSpace(character) && Char.IsUpper(character) && i != 0 && !Char.IsUpper(source[i - 1]) && !Char.IsWhiteSpace(source[i - 1]))
                {
                    builder.Append(" ");
                }

                builder.Append(character);
            }

            return builder.ToString();
        }
    }
}

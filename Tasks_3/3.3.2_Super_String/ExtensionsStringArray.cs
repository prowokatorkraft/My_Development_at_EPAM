using System.Linq;

namespace _3._3._2_Super_String
{
    internal static class ExtensionsStringArray
    {
        public static LanguageWord DefineLanguageWord(this string str)
        {
            if (str.All(ch => ch >= '\x41' && ch <= '\x7A'))
            {
                return LanguageWord.English;
            }
            else if (str.All(ch => ch >= '\x400' && ch <= '\x4FF'))
            {
                return LanguageWord.Russian;
            }
            else
            {
                return LanguageWord.Mixed;
            }
        }
    }
}

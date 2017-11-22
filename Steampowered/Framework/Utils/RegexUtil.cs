using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Framework.Utils
{
    public class RegexUtil
    {
        private static List<int> GetMatchListInt(string patternStr, string text)
        {
            var discountsGame = new List<int>();
            foreach (Match match in Regex.Matches(text, patternStr, RegexOptions.IgnoreCase))
            {
                discountsGame.Add(Int32.Parse(match.Value));
            }
            return discountsGame;
        }

        public static int GetMatchMaxInt(string patternStr, string textElement)
        {
            var discounts = GetMatchListInt(patternStr, textElement);
            discounts.Sort();
            return discounts.Last();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class Pangram
        : Challenge<string, string>
    {
        protected override string Run(string input)
        {
            var lettersRemaining = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
            var lowerInput = input.ToLowerInvariant();

            foreach (var letter in lowerInput)
            {
                if (lettersRemaining.Contains(letter))
                {
                    lettersRemaining.Remove(letter);
                }

                if (lettersRemaining.Count == 0)
                {
                    return "pangram";
                }
            }

            return "not pangram";
        }

        public override IEnumerable<(string input, string expectedResult)> TestCases()
        {
            return new[]
            {
                ("We promptly judged antique ivory buckles for the next prize", "pangram"),
                ("We promptly judged antique ivory buckles for the prize", "not pangram")
            };
        }
    }
}

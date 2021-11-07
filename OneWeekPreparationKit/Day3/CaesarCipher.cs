using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneWeekPreparationKit.Day3
{
    public static class CaesarCipher
    {
        public static void Run()
        {
            var testCases = TestCases();
            foreach (var test in testCases)
            {
                Console.WriteLine(caesarCipher(test.Item1, test.Item2));
            }
        }

        public static string caesarCipher(string s, int shift)
        {
            var rotatedAlphabet = GetRotatedAlphabet(shift);

            var sb = new StringBuilder();

            foreach (var c in s)
            {
                sb.Append(ShiftCharacter(rotatedAlphabet, c));
            }

            return sb.ToString();
        }

        public static string GetRotatedAlphabet(int shift)
        {
            shift %= 26;

            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var firstPart = alphabet.Substring(0, shift);
            return alphabet.Substring(shift) + firstPart;
        }

        public static char ShiftCharacter(string alphabet, char c)
        {
            if (!char.IsLetter(c))
            {
                return c;
            }

            var isUpper = char.IsUpper(c);
            var index = char.ToLowerInvariant(c) - 'a';
            var result = alphabet[index];

            if (isUpper)
            {
                return char.ToUpperInvariant(result);
            }

            return result;
        }

        public static IList<(string, int)> TestCases()
        {
            return new[] { ("middle-Outz", 52) };
        }
    }
}

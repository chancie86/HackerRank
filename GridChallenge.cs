using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static class GridChallenge
    {
        public static void Run()
        {
            var testCases = TestCases();

            foreach (var test in testCases)
            {
                Console.WriteLine(gridChallenge(test));
            }
        }

        public static string gridChallenge(char[][] grid)
        {
            // Order the rows by char
            for (var row = 0; row < grid.Length; row++)
            {
                grid[row] = grid[row].OrderBy(x => x).ToArray();
            }

            for (var column = 0; column < grid[0].Length; column++)
            {
                var tmp = 0;
                for (var row = 0; row < grid.Length; row++)
                {
                    if (tmp > grid[row][column])
                    {
                        return "NO";
                    }

                    tmp = grid[row][column];
                }
            }

            return "YES";
        }

        private static IEnumerable<char[][]> TestCases()
        {
            var testData = new []
            {
                new [] { "ebacd", "fghij", "olmkn", "trpqs", "xywuv" },
                new [] { "abc", "lmp", "qrt" },
                new [] { "mpxz", "abcd", "wlmf" },
                new [] { "abc", "hjk", "mpq", "rtv" }
            };

            return testData.Select(x => ConvertToGrid(x));
        }

        private static char[][] ConvertToGrid(IList<string> input)
        {
            var grid = new char[input.Count][];
            for (var row = 0; row < grid.Length; row++)
            {
                grid[row] = input[row].ToCharArray();
            }

            return grid;
        }
    }
}

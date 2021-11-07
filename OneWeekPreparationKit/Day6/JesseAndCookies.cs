using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HackerRank.Collections;

namespace HackerRank.OneWeekPreparationKit.Day6
{
    public static class JesseAndCookies
    {
        public static void Run()
        {
            var i = 0;
            foreach (var test in TestCases())
            {
                Console.WriteLine($"Test {++i}");
                var result = cookies(test.Item1, test.Item2);
                Console.WriteLine(result);
            }
        }

        private static int cookies(int k, IList<int> A)
        {
            var iterations = 0;
            //var cookies = new SortedList<int>(A);
            var cookies = new MinHeap<int>(A);

            while (true)
            {
                var leastSweetCookie = cookies.RemoveFirst();

                if (leastSweetCookie >= k)
                {
                    // All other cookies are >= k so we're done
                    return iterations;
                }

                if (cookies.Count == 0)
                {
                    // No more cookies to mix
                    return -1;
                }

                var secondLeastSweetCookie = cookies.RemoveFirst();

                //Console.WriteLine($"{leastSweetCookie} {secondLeastSweetCookie}");

                cookies.Add(leastSweetCookie + 2 * secondLeastSweetCookie);

                iterations++;
            }
        }

        private static IEnumerable<(int, IList<int>)> TestCases()
        {
            return new[]
            {
                (9, new [] { 2, 7, 3, 6, 4, 6 }),
                (7, new [] { 1, 2, 3, 9, 10, 12 }),
                (1059589, ReadValuesFromFile("OneWeekPreparationKit\\Day6\\TestCase10.txt")),
                (105823341, ReadValuesFromFile("OneWeekPreparationKit\\Day6\\TestCase18.txt")),
            };
        }

        private static IList<int> ReadValuesFromFile(string fileName)
        {
            return File.ReadAllLines(fileName).Select(int.Parse).ToArray();
        }
    }
}

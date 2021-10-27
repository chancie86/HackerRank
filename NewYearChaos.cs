using System;
using System.Collections.Generic;

namespace HackerRank
{
    public static class NewYearChaos
    {
        public static void Run()
        {
            foreach (var test in TestCases())
            {
                minimumBribes(test);
            }
        }

        public static void minimumBribes(IList<int> q)
        {
            var totalBribes = 0;
            var seen = new HashSet<int>();
            
            for (var i = 0; i < q.Count; i++)
            {
                var initialPosition = q[i];

                if (initialPosition > (i + 3))
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                seen.Add(initialPosition);
                var numBribed = NumberBribed(q, seen, initialPosition);
                totalBribes += numBribed;
            }

            Console.WriteLine(totalBribes);
        }

        public static int NumberBribed(IList<int> q, HashSet<int> seen, int initialPosition)
        {
            if (initialPosition == 1)
            {
                // First person cannot bribe anyone
                return 0;
            }

            if (initialPosition == 2)
            {
                // Second person can only bribe the first
                if (seen.Contains(1))
                {
                    return 0;
                }
                
                return 1;
            }

            var numBribed = 0;

            if (!seen.Contains(initialPosition - 1))
            {
                numBribed++;
            }

            if (!seen.Contains(initialPosition - 2))
            {
                numBribed++;
            }

            return numBribed;
        }

        private static IEnumerable<IList<int>> TestCases()
        {
            return new[]
            {
                new [] { 2, 1, 5, 3, 4 },
                new [] { 2, 5, 1, 3, 4 },
                new [] { 5, 1, 2, 3, 7, 8, 6, 4 },
                new [] { 1, 2, 5, 3, 7, 8, 6, 4 }
            };
        }
    }
}

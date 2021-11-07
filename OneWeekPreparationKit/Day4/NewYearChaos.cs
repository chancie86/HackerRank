using System;
using System.Collections.Generic;

namespace HackerRank.OneWeekPreparationKit.Day4
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
            var workingSet = new int[q.Count];
            for (var i = 0; i < q.Count; i++)
            {
                workingSet[i] = i + 1;
            }

            var totalBribes = 0;

            for (var i = 0; i < q.Count; i++)
            {
                var actualPerson = q[i];
                var expectedPerson = workingSet[i];

                if (expectedPerson == actualPerson)
                {
                    continue;
                }

                var currentBribes = 0;

                while (expectedPerson != actualPerson)
                {
                    Bribe(i, workingSet, actualPerson);
                    expectedPerson = workingSet[i];
                    totalBribes++;
                    currentBribes++;

                    if (currentBribes > 2)
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }
            }

            Console.WriteLine(totalBribes);
        }

        private static void Bribe(int startIndex, int[] workingSet, int person)
        {
            for (var i = startIndex; i < workingSet.Length; i++)
            {
                if (workingSet[i] == person)
                {
                    // Bribe the person in front
                    Swap(i, i - 1, workingSet);
                    return;
                }
            }
        }

        private static void Swap(int index1, int index2, int[] array)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        private static IEnumerable<IList<int>> TestCases()
        {
            return new[]
            {
                new [] { 2, 1, 5, 3, 4 },
                new [] { 2, 5, 1, 3, 4 },
                new [] { 1, 2, 5, 3, 4, 7, 8, 6 },
                new [] { 5, 1, 2, 3, 7, 8, 6, 4 },
                new [] { 1, 2, 5, 3, 7, 8, 6, 4 }
            };
        }
    }
}

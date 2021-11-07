using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class MiniMaxSum
        : Challenge<List<int>>
    {
        protected override void Run(List<int> input)
        {
            long smallest = long.MaxValue, largest = long.MinValue, total = 0;

            foreach (var i in input)
            {
                total += i;
                smallest = Math.Min(smallest, i);
                largest = Math.Max(largest, i);
            }

            Console.WriteLine($"{(total - largest)} {(total - smallest)}");
        }

        public override IEnumerable<List<int>> TestCases()
        {
            return new[]
            {
                new List<int> {1, 2, 3, 4, 5}
            };
        }
    }
}

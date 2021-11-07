using System;
using System.Collections.Generic;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class PlusMinus
        : Challenge<List<int>>
    {
        protected override void Run(List<int> input)
        {
            int numPositive = 0, numZero = 0, numNegative = 0;

            foreach (var num in input)
            {
                if (num < 0)
                {
                    numNegative++;
                }
                else if (num == 0)
                {
                    numZero++;
                }
                else
                {
                    numPositive++;
                }
            }

            PrintResult(input, numPositive);
            PrintResult(input, numNegative);
            PrintResult(input, numZero);
        }

        private void PrintResult(IList<int> input, int result)
        {
            var ratio = Math.Round((double) result / input.Count, 6);
            Console.WriteLine($"{string.Format("{0:0.000000}", ratio)}");
        }

        public override IEnumerable<List<int>> TestCases()
        {
            return new List<List<int>>
            {
                new List<int> { -4, 3, -9, 0, 4, 1 }
            };
        }
    }
}

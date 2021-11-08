using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class DiagonalDifference
        : Challenge<List<List<int>>, int>
    {
        protected override int Run(List<List<int>> arr)
        {
            var dimensions = arr.Count;
            int ltrSum = 0, rtlSum = 0;

            for (var row = 0; row < dimensions; row++)
            {
                var ltrColumn = row;
                var rtlColumn = dimensions - row - 1;

                ltrSum += arr[row][ltrColumn];
                rtlSum += arr[row][rtlColumn];
            }

            return Math.Abs(ltrSum - rtlSum);
        }

        public override IEnumerable<(List<List<int>> input, int expectedResult)> TestCases()
        {
            return new List<(List<List<int>> input, int expectedResult)> {
                (
                    new List<List<int>>
                    {
                        new List<int> { 11, 2, 4 },
                        new List<int> { 4, 5, 6 },
                        new List<int> { 10, 8, -12 },
                    },
                    15
                )
            };
        }
    }
}

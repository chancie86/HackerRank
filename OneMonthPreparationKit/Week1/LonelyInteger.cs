using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class LonelyInteger
        : Challenge<List<int>, int>
    {
        protected override int Run(List<int> a)
        {
            var workingSet = new HashSet<int>();
            foreach (var x in a)
            {
                if (workingSet.Contains(x))
                {
                    workingSet.Remove(x);
                }
                else
                {
                    workingSet.Add(x);
                }
            }

            return workingSet.Single();
        }

        public override IEnumerable<(List<int> input, int expectedResult)> TestCases()
        {
            return new List<(List<int>, int)>
            {
                (new List<int> {1, 2, 3, 4, 3, 2, 1}, 4),
            };
        }
    }
}

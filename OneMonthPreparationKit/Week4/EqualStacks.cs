using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HackerRank.OneMonthPreparationKit.Week4
{
    public class EqualStacks
        : Challenge<(IList<int> h1, IList<int> h2, IList<int> h3), int>
    {
        protected override int Run((IList<int> h1, IList<int> h2, IList<int> h3) input)
        {
            var h1 = input.h1;
            var h2 = input.h2;
            var h3 = input.h3;

            var heights = GetHeights(h1, h2, h3);

            while (!AreEqualHeights(heights))
            {
                var tallestStack = GetTallestStack(heights);

                // Remove first cylinder from stack
                var cylinderHeight = tallestStack[0];
                tallestStack.RemoveAt(0);
                heights[tallestStack] -= cylinderHeight;
            }

            return heights.First().Value;
        }

        private static bool AreEqualHeights(Dictionary<IList<int>, int> heights)
        {
            var firstHeight = heights.First().Value;

            foreach (var stack in heights.Keys)
            {
                if (heights[stack] != firstHeight)
                {
                    return false;
                }
            }

            return true;
        }

        private static IList<int> GetTallestStack(Dictionary<IList<int>, int> heights)
        {
            IList<int> maxKey = null;
            var max = 0;

            foreach (var key in heights.Keys)
            {
                if (heights[key] > max)
                {
                    maxKey = key;
                    max = heights[key];
                }
            }

            return maxKey;
        }

        private static Dictionary<IList<int>, int> GetHeights(IList<int> h1, IList<int> h2, IList<int> h3)
        {
            var h1Height = h1.Sum(x => x);
            var h2Height = h2.Sum(x => x);
            var h3Height = h3.Sum(x => x);

            return new Dictionary<IList<int>, int>
            {
                { h1, h1Height },
                { h2, h2Height },
                { h3, h3Height }
            };
        }

        public override IEnumerable<((IList<int> h1, IList<int> h2, IList<int> h3) input, int expectedResult)> TestCases()
        {
            return new List<((IList<int> h1, IList<int> h2, IList<int> h3) input, int expectedResult)>
            {
                (
                    (
                        new List<int> { 3, 2, 1, 1, 1 },
                        new List<int> { 4, 3, 2 },
                        new List<int> { 1, 1, 4, 1 }
                    ),
                    5
                )
            };
        }
    }
}

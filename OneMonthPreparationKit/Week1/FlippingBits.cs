using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class FlippingBits
        : Challenge<long, long>
    {
        protected override long Run(long input)
        {
            long mask = 1;
            long result = 0;

            for (var i = 0; i < 32; i++)
            {
                long val = (input & mask) == 0 ? mask : 0;
                result |= val;
                mask = mask << 1;
            }

            return result;
        }

        public override IEnumerable<(long input, long expectedResult)> TestCases()
        {
            return new[]
            {
                (2147483647L, 2147483648),
                (1L, 4294967294L),
                (0L, 4294967295)
            };
        }
    }
}

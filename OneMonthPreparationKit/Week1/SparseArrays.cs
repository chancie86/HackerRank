using System;
using System.Collections.Generic;
using System.Linq;
using HackerRank.Collections;

namespace HackerRank.OneMonthPreparationKit.Week1
{
    public class SparseArrays
        : Challenge<(IList<string> strings, IList<string> queries), IList<int>>
    {
        protected override IList<int> Run((IList<string> strings, IList<string> queries) input)
        {
            return matchingStrings(input.strings, input.queries);
        }

        private static List<int> matchingStrings(IList<string> strings, IList<string> queries)
        {
            var occurrences = new Dictionary<string, (bool seen, int occurrences)>();
            foreach (var query in queries)
            {
                if (!occurrences.ContainsKey(query))
                {
                    occurrences[query] = (false, 0);
                }
            }

            foreach (var query in queries)
            {
                var val = occurrences[query];

                if (val.seen)
                {
                    continue;
                }

                foreach (var s in strings)
                {
                    if (string.Equals(s, query, StringComparison.Ordinal))
                    {
                        val.occurrences++;
                    }
                }

                val.seen = true;
                occurrences[query] = val;
            }

            return queries.Select(q => occurrences[q].occurrences).ToList();
        }

        public override IEnumerable<((IList<string> strings, IList<string> queries) input, IList<int> expectedResult)> TestCases()
        {
            return new List<((IList<string> strings, IList<string> queries) input, IList<int> expectedResult)>
            {
                //((new [] { "aba", "baba", "aba", "xzxb" }, new [] { "aba", "xzxb", "ab" }), new ComparableList<int> { 2, 1, 0 }),
                //((new [] { "def", "de", "fgh" }, new [] { "de", "lmn", "fgh" }), new ComparableList<int> { 1, 0, 1 }),
                //((new [] { "abcde", "sdaklfj", "asdjf", "na", "basdn", "sdaklfj", "asdjf", "na", "asdjf", "na", "basdn", "sdaklfj", "asdjf" }, new [] { "abcde", "sdaklfj", "asdjf", "na", "basdn" }), new ComparableList<int> { 1, 3, 4, 3, 2 }),
                ((new [] { "praxzvkszqgrao", "yxqfteyrbnlpm", "kyvdrzjukegybes", "sxxxfddtblyjel", "sxxxfddtblyjel", "nidhjduqnhaqrqezsyf", "yxqfteyrbnlpm", "xpvcsosjxbp", "sqktxxojezjtqwxugtp", "sxxxfddtblyjel", "nidhjduqnhaqrqezsyf", "praxzvkszqgrao", "yxqfteyrbnlpm", "kkfufcpxrhhhc", "praxzvkszqgrao", "xpvcsosjxbp", "kwmpitjxwbexpa", "yxqfteyrbnlpm", "praxzvkszqgrao", "yxqfteyrbnlpm", "sxxxfddtblyjel", "kkfufcpxrhhhc", "kyvdrzjukegybes", "kyvdrzjukegybes", "sqktxxojezjtqwxugtp", "nidhjduqnhaqrqezsyf", "nqnfdyhwqih", "praxzvkszqgrao", "uriuywohcovpooa", "kyvdrzjukegybes", "nidhjduqnhaqrqezsyf", "sqktxxojezjtqwxugtp", "nidhjduqnhaqrqezsyf", "nqnfdyhwqih", "uriuywohcovpooa", "nidhjduqnhaqrqezsyf", "kwmpitjxwbexpa", "nidhjduqnhaqrqezsyf", "sxxxfddtblyjel", "nqnfdyhwqih", "yxqfteyrbnlpm", "nidhjduqnhaqrqezsyf", "kyvdrzjukegybes", "uriuywohcovpooa", "kkfufcpxrhhhc", "kwmpitjxwbexpa", "nidhjduqnhaqrqezsyf", "kwmpitjxwbexpa", "xpvcsosjxbp", "pjkzhwasks", "nidhjduqnhaqrqezsyf", "nqnfdyhwqih", "kkfufcpxrhhhc", "nidhjduqnhaqrqezsyf", "praxzvkszqgrao", "kkfufcpxrhhhc", "xpvcsosjxbp", "sxxxfddtblyjel", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "pjkzhwasks", "pjkzhwasks", "xpvcsosjxbp", "yxqfteyrbnlpm", "uriuywohcovpooa", "xpvcsosjxbp", "nidhjduqnhaqrqezsyf", "sqktxxojezjtqwxugtp", "kwmpitjxwbexpa", "pjkzhwasks", "sxxxfddtblyjel", "praxzvkszqgrao", "kwmpitjxwbexpa", "kkfufcpxrhhhc", "kwmpitjxwbexpa", "sxxxfddtblyjel", "sxxxfddtblyjel", "nidhjduqnhaqrqezsyf", "yxqfteyrbnlpm", "nqnfdyhwqih", "nqnfdyhwqih", "uriuywohcovpooa", "nqnfdyhwqih", "xpvcsosjxbp", "praxzvkszqgrao", "praxzvkszqgrao", "kkfufcpxrhhhc", "kkfufcpxrhhhc", "sxxxfddtblyjel", "pjkzhwasks", "kwmpitjxwbexpa", "pjkzhwasks", "sxxxfddtblyjel", "pjkzhwasks", "pjkzhwasks", "nqnfdyhwqih", "kwmpitjxwbexpa", "kkfufcpxrhhhc", "xpvcsosjxbp", "uriuywohcovpooa", "kyvdrzjukegybes", "sxxxfddtblyjel", "uriuywohcovpooa", "sxxxfddtblyjel", "sqktxxojezjtqwxugtp", "uriuywohcovpooa", "kyvdrzjukegybes", "xpvcsosjxbp", "kwmpitjxwbexpa", "kwmpitjxwbexpa", "praxzvkszqgrao", "kyvdrzjukegybes", "sxxxfddtblyjel", "praxzvkszqgrao", "nqnfdyhwqih", "nqnfdyhwqih", "praxzvkszqgrao", "nqnfdyhwqih", "kyvdrzjukegybes", "kkfufcpxrhhhc", "sxxxfddtblyjel", "kyvdrzjukegybes", "kyvdrzjukegybes" }, new [] { "kwmpitjxwbexpa", "yxqfteyrbnlpm", "xpvcsosjxbp", "sqktxxojezjtqwxugtp", "yxqfteyrbnlpm", "xpvcsosjxbp", "pjkzhwasks", "sxxxfddtblyjel", "kkfufcpxrhhhc", "sxxxfddtblyjel", "uriuywohcovpooa", "praxzvkszqgrao", "kkfufcpxrhhhc", "sqktxxojezjtqwxugtp", "kyvdrzjukegybes", "sqktxxojezjtqwxugtp", "kkfufcpxrhhhc", "praxzvkszqgrao", "kkfufcpxrhhhc", "kkfufcpxrhhhc", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "kwmpitjxwbexpa", "nidhjduqnhaqrqezsyf", "sxxxfddtblyjel", "nidhjduqnhaqrqezsyf", "nidhjduqnhaqrqezsyf", "nqnfdyhwqih", "nidhjduqnhaqrqezsyf", "xpvcsosjxbp", "uriuywohcovpooa", "sxxxfddtblyjel", "xpvcsosjxbp", "uriuywohcovpooa", "kyvdrzjukegybes", "xpvcsosjxbp", "xpvcsosjxbp", "yxqfteyrbnlpm", "nidhjduqnhaqrqezsyf", "nidhjduqnhaqrqezsyf", "sqktxxojezjtqwxugtp", "sxxxfddtblyjel", "kyvdrzjukegybes", "xpvcsosjxbp", "uriuywohcovpooa", "pjkzhwasks", "kyvdrzjukegybes", "xpvcsosjxbp", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "uriuywohcovpooa", "sxxxfddtblyjel", "nidhjduqnhaqrqezsyf", "kwmpitjxwbexpa", "pjkzhwasks", "nidhjduqnhaqrqezsyf", "kwmpitjxwbexpa", "xpvcsosjxbp", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "yxqfteyrbnlpm", "nidhjduqnhaqrqezsyf", "yxqfteyrbnlpm", "kkfufcpxrhhhc", "kkfufcpxrhhhc", "xpvcsosjxbp", "sqktxxojezjtqwxugtp", "xpvcsosjxbp", "kyvdrzjukegybes", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "nqnfdyhwqih", "sxxxfddtblyjel", "pjkzhwasks", "praxzvkszqgrao", "nidhjduqnhaqrqezsyf", "pjkzhwasks", "praxzvkszqgrao", "kwmpitjxwbexpa", "kkfufcpxrhhhc", "uriuywohcovpooa", "sxxxfddtblyjel", "yxqfteyrbnlpm", "yxqfteyrbnlpm", "kwmpitjxwbexpa", "nqnfdyhwqih", "yxqfteyrbnlpm", "yxqfteyrbnlpm", "sqktxxojezjtqwxugtp", "sxxxfddtblyjel", "pjkzhwasks", "sxxxfddtblyjel", "sqktxxojezjtqwxugtp", "nidhjduqnhaqrqezsyf", "kkfufcpxrhhhc", "nqnfdyhwqih", "kyvdrzjukegybes", "sqktxxojezjtqwxugtp", "yxqfteyrbnlpm", "kwmpitjxwbexpa", "nqnfdyhwqih", "xpvcsosjxbp", "sxxxfddtblyjel", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "nqnfdyhwqih", "xpvcsosjxbp", "xpvcsosjxbp", "xpvcsosjxbp", "yxqfteyrbnlpm", "nidhjduqnhaqrqezsyf", "kwmpitjxwbexpa", "uriuywohcovpooa", "kyvdrzjukegybes", "nqnfdyhwqih", "uriuywohcovpooa", "pjkzhwasks", "nidhjduqnhaqrqezsyf", "nidhjduqnhaqrqezsyf", "kyvdrzjukegybes", "nqnfdyhwqih", "kwmpitjxwbexpa", "kwmpitjxwbexpa", "uriuywohcovpooa", "kyvdrzjukegybes", "nidhjduqnhaqrqezsyf", "kwmpitjxwbexpa", "xpvcsosjxbp", "nidhjduqnhaqrqezsyf", "kkfufcpxrhhhc", "nidhjduqnhaqrqezsyf", "yxqfteyrbnlpm", "uriuywohcovpooa", "nidhjduqnhaqrqezsyf", "praxzvkszqgrao", "praxzvkszqgrao", "yxqfteyrbnlpm", "kwmpitjxwbexpa", "yxqfteyrbnlpm", "uriuywohcovpooa", "nqnfdyhwqih", "praxzvkszqgrao", "kwmpitjxwbexpa", "kkfufcpxrhhhc", "praxzvkszqgrao", "xpvcsosjxbp", "yxqfteyrbnlpm", "kkfufcpxrhhhc", "sxxxfddtblyjel", "kwmpitjxwbexpa", "nqnfdyhwqih", "yxqfteyrbnlpm", "kkfufcpxrhhhc", "sqktxxojezjtqwxugtp", "xpvcsosjxbp", "praxzvkszqgrao", "xpvcsosjxbp", "sqktxxojezjtqwxugtp", "sxxxfddtblyjel", "sqktxxojezjtqwxugtp", "pjkzhwasks", "kyvdrzjukegybes", "praxzvkszqgrao", "yxqfteyrbnlpm", "sxxxfddtblyjel", "pjkzhwasks", "sxxxfddtblyjel", "uriuywohcovpooa", "xpvcsosjxbp", "xpvcsosjxbp", "praxzvkszqgrao", "uriuywohcovpooa", "praxzvkszqgrao", "kkfufcpxrhhhc", "praxzvkszqgrao", "kwmpitjxwbexpa", "uriuywohcovpooa", "uriuywohcovpooa", "uriuywohcovpooa", "nqnfdyhwqih", "nidhjduqnhaqrqezsyf", "kkfufcpxrhhhc", "kkfufcpxrhhhc", "kkfufcpxrhhhc", "pjkzhwasks", "kyvdrzjukegybes", "sqktxxojezjtqwxugtp", "sqktxxojezjtqwxugtp", "uriuywohcovpooa", "xpvcsosjxbp", "kwmpitjxwbexpa", "xpvcsosjxbp", "kkfufcpxrhhhc", "uriuywohcovpooa", "sxxxfddtblyjel", "sxxxfddtblyjel", "yxqfteyrbnlpm", "kkfufcpxrhhhc", "nqnfdyhwqih", "uriuywohcovpooa", "sxxxfddtblyjel", "nqnfdyhwqih", "sqktxxojezjtqwxugtp", "yxqfteyrbnlpm", "nqnfdyhwqih", "kyvdrzjukegybes", "praxzvkszqgrao", "yxqfteyrbnlpm", "uriuywohcovpooa", "uriuywohcovpooa", "nqnfdyhwqih", "sqktxxojezjtqwxugtp", "kyvdrzjukegybes", "pjkzhwasks", "sxxxfddtblyjel", "yxqfteyrbnlpm", "kyvdrzjukegybes", "praxzvkszqgrao", "xpvcsosjxbp", "sxxxfddtblyjel", "praxzvkszqgrao", "kyvdrzjukegybes", "kwmpitjxwbexpa", "uriuywohcovpooa", "xpvcsosjxbp", "sqktxxojezjtqwxugtp", "pjkzhwasks", "praxzvkszqgrao", "kkfufcpxrhhhc", "yxqfteyrbnlpm", "nidhjduqnhaqrqezsyf", "kyvdrzjukegybes", "pjkzhwasks", "yxqfteyrbnlpm", "pjkzhwasks", "kyvdrzjukegybes", "yxqfteyrbnlpm", "kyvdrzjukegybes", "sxxxfddtblyjel", "kwmpitjxwbexpa", "uriuywohcovpooa", "pjkzhwasks", "praxzvkszqgrao", "nqnfdyhwqih", "nqnfdyhwqih", "sxxxfddtblyjel", "kkfufcpxrhhhc", "pjkzhwasks", "kwmpitjxwbexpa", "nidhjduqnhaqrqezsyf", "kkfufcpxrhhhc", "xpvcsosjxbp", "nqnfdyhwqih", "sqktxxojezjtqwxugtp", "yxqfteyrbnlpm", "pjkzhwasks", "yxqfteyrbnlpm", "sxxxfddtblyjel", "kkfufcpxrhhhc", "yxqfteyrbnlpm", "yxqfteyrbnlpm", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "sxxxfddtblyjel", "sqktxxojezjtqwxugtp", "nqnfdyhwqih", "sxxxfddtblyjel", "nidhjduqnhaqrqezsyf", "sqktxxojezjtqwxugtp", "nqnfdyhwqih", "sxxxfddtblyjel", "kkfufcpxrhhhc", "kkfufcpxrhhhc", "nqnfdyhwqih", "sqktxxojezjtqwxugtp", "kwmpitjxwbexpa", "praxzvkszqgrao", "sxxxfddtblyjel", "pjkzhwasks", "nqnfdyhwqih", "kwmpitjxwbexpa", "praxzvkszqgrao", "nidhjduqnhaqrqezsyf", "sxxxfddtblyjel", "kkfufcpxrhhhc", "yxqfteyrbnlpm", "yxqfteyrbnlpm", "xpvcsosjxbp", "kkfufcpxrhhhc", "kwmpitjxwbexpa", "praxzvkszqgrao", "nqnfdyhwqih", "xpvcsosjxbp", "praxzvkszqgrao", "yxqfteyrbnlpm", "yxqfteyrbnlpm", "praxzvkszqgrao", "kwmpitjxwbexpa", "pjkzhwasks", "sqktxxojezjtqwxugtp", "pjkzhwasks", "yxqfteyrbnlpm", "sqktxxojezjtqwxugtp", "kwmpitjxwbexpa", "nqnfdyhwqih", "uriuywohcovpooa", "kyvdrzjukegybes", "kwmpitjxwbexpa", "nqnfdyhwqih", "uriuywohcovpooa", "sqktxxojezjtqwxugtp", "yxqfteyrbnlpm", "xpvcsosjxbp", "yxqfteyrbnlpm", "yxqfteyrbnlpm", "xpvcsosjxbp", "yxqfteyrbnlpm", "uriuywohcovpooa", "nqnfdyhwqih", "kyvdrzjukegybes", "kkfufcpxrhhhc" }), new ComparableList<int> { 11,8,9,6,8,9,8,15,10,15,9,12,10,6,11,6,10,12,10,10,9,6,11,13,15,13,13,11,13,9,9,15,9,9,11,9,9,8,13,13,6,15,11,9,9,8,11,9,9,6,9,15,13,11,8,13,11,9,9,6,8,13,8,10,10,9,6,9,11,9,6,11,15,8,12,13,8,12,11,10,9,15,8,8,11,11,8,8,6,15,8,15,6,13,10,11,11,6,8,11,11,9,15,9,6,11,9,9,9,8,13,11,9,11,11,9,8,13,13,11,11,11,11,9,11,13,11,9,13,10,13,8,9,13,12,12,8,11,8,9,11,12,11,10,12,9,8,10,15,11,11,8,10,6,9,12,9,6,15,6,8,11,12,8,15,8,15,9,9,9,12,9,12,10,12,11,9,9,9,11,13,10,10,10,8,11,6,6,9,9,11,9,10,9,15,15,8,10,11,9,15,11,6,8,11,11,12,8,9,9,11,6,11,8,15,8,11,12,9,15,12,11,11,9,9,6,8,12,10,8,13,11,8,8,8,11,8,11,15,11,9,8,12,11,11,15,10,8,11,13,10,9,11,6,8,8,8,15,10,8,8,9,6,15,6,11,15,13,6,11,15,10,10,11,6,11,12,15,8,11,11,12,13,15,10,8,8,9,10,11,12,11,9,12,8,8,12,11,8,6,8,8,6,11,11,9,11,11,11,9,6,8,9,8,8,9,8,9,11,11,10 }),
            };
        }
    }
}

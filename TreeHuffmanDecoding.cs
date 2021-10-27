using System;
using System.Collections.Generic;
using System.Text;
using HackerRank.Huffman;

namespace HackerRank
{
    public static partial class TreeHuffmanDecoding
    {
        public static void Run()
        {
            foreach (var test in TestCases())
            {
                var encodedValue = Setup(test, out var root);
                decode(encodedValue, root);
            }
        }

        private static void decode(String s, Node root)
        {
            var buffer = new StringBuilder();
            var node = root;

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];

                switch (currentChar)
                {
                    case '0':
                        node = node.left;
                        break;
                    case '1':
                        node = node.right;
                        break;
                }

                if (isLeaf(node))
                {
                    buffer.Append(node.data);

                    // Move onto next code
                    node = root;
                }
            }

            Console.WriteLine(buffer.ToString());
        }

        private static bool isLeaf(Node node)
        {
            return node.left == null && node.right == null;
        }

        private static IEnumerable<string> TestCases()
        {
            return new[]
            {
                "ABACA",
                "DSGHJKTSEHJKDHJKXFGDNMSREZHJKL"
            };
        }
    }
}

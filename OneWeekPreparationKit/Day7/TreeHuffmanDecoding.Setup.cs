using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HackerRank.Collections;
using HackerRank.OneWeekPreparationKit.Day7.Huffman;

namespace HackerRank.OneWeekPreparationKit.Day7
{
    public static partial class TreeHuffmanDecoding
    {
        public static Dictionary<char, string> mapA = new Dictionary<char, string>();

        public static string Setup(string test, out Node root)
        {
            // we will assume that all our characters will have
            // code less than 256, for simplicity
            var charFreqs = new int[256];

            // read each character and record the frequencies
            foreach (var c in test.ToCharArray())
            {
                charFreqs[c]++;
            }

            // build tree
            Node tree = buildTree(charFreqs);

            // print out results
            printCodes(tree, new StringBuilder());
            var s = new StringBuilder();

            for (int i = 0; i < test.Length; i++)
            {
                char c = test[i];
                s.Append(mapA[c]);
            }

            //System.out.println(s);
            root = tree;
            return s.ToString();
        }

        // input is an array of frequencies, indexed by character code
        public static Node buildTree(int[] charFreqs)
        {
            var trees = new PriorityQueue<Node>();
            // initially, we have a forest of leaves
            // one for each non-empty character
            for (int i = 0; i < charFreqs.Length; i++)
                if (charFreqs[i] > 0)
                    trees.Enqueue(new HuffmanLeaf(charFreqs[i], (char)i));

            Debug.Assert(trees.Count() > 0);

            // loop until there is only one tree left
            while (trees.Count() > 1)
            {
                // two trees with least frequency
                Node a = trees.Dequeue();
                Node b = trees.Dequeue();

                // put into new node and re-insert into queue
                trees.Enqueue(new HuffmanNode(a, b));
            }

            return trees.Dequeue();
        }

        public static void printCodes(Node tree, StringBuilder prefix)
        {
            Debug.Assert(tree != null);

            if (tree is HuffmanLeaf)
            {
                HuffmanLeaf leaf = (HuffmanLeaf)tree;

                // print out character, frequency, and code for this leaf (which is just the prefix)
                //System.out.println(leaf.data + "\t" + leaf.frequency + "\t" + prefix);
                mapA[leaf.data] = prefix.ToString();
            }
            else if (tree is HuffmanNode)
            {
                HuffmanNode node = (HuffmanNode)tree;

                // traverse left
                prefix.Append('0');
                printCodes(node.left, prefix);
                prefix.Remove(prefix.Length - 1, 1);

                // traverse right
                prefix.Append('1');
                printCodes(node.right, prefix);
                prefix.Remove(prefix.Length - 1, 1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneWeekPreparationKit.Day7.Huffman
{
    public abstract class Node
        : IComparable<Node>
    {
        public int frequency; // the frequency of this tree
        public char data;
        public Node left, right;

        public Node(int freq)
        {
            frequency = freq;
        }

        public int CompareTo(Node tree)
        {
            return frequency - tree.frequency;
        }
    }
}

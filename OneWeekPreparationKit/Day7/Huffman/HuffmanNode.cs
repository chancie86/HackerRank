using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.OneWeekPreparationKit.Day7.Huffman
{
    public class HuffmanNode
        : Node
    {
        public HuffmanNode(Node l, Node r)
            : base(l.frequency + r.frequency)
        {
            left = l;
            right = r;
        }

    }
}

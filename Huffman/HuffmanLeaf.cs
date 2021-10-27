using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.Huffman
{
    public class HuffmanLeaf
        : Node
    {
        public HuffmanLeaf(int freq, char val)
            : base(freq)
        {
            data = val;
        }
    }
}

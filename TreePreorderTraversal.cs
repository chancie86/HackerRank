using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank
{
    public static partial class TreePreorderTraversal
    {


        public static void preOrder(Node root)
        {
            Console.Write(root.data);

            if (root.left != null)
            {
                Console.Write(' ');
                preOrder(root.left);
            }

            if (root.right != null)
            {
                Console.Write(' ');
                preOrder(root.right);
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace HackerRank
{
    public static partial class TreePreorderTraversal
    {
        public static void Run()
        {
            foreach (var test in TestCases())
            {
                var root = Setup(test);
                preOrder(root);
            }
        }

        private static IEnumerable<string> TestCases()
        {
            return new[]
            {
                "1 2 5 3 6 4"
            };
        }

        private static Node Setup(string input)
        {
            var values = input.Split(' ').Select(x => int.Parse(x));

            Node root = null;
            foreach (var data in values)
            {
                root = insert(root, data);
            }

            return root;
        }

        private static Node insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.data)
                {
                    cur = insert(root.left, data);
                    root.left = cur;
                }
                else
                {
                    cur = insert(root.right, data);
                    root.right = cur;
                }
                return root;
            }
        }

        public class Node
        {
            public Node left;
            public Node right;
            public int data;

            public Node(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace InorderTraversal
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode root = new TreeNode(val: 1,
                left: new TreeNode(val: 2,
                    left: new TreeNode(val: 4),
                    right: new TreeNode(val: 5)),
                right: new TreeNode(val: 3));
            foreach (int val in GetInorder(root))
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
            foreach (int val in GetInorder2(root))
            {
                Console.Write(val + " ");
            }
        }

        static IEnumerable<int> GetInorder(TreeNode root)
        {
            List<int> result = new List<int>();

            GetInorderInternal(root, result);

            return result;
        }

        static IEnumerable<int> GetInorder2(TreeNode root)
        {
            List<int> result = new List<int>();

            GetInorderInternal2(root, result);

            return result;
        }

        static void GetInorderInternal2(TreeNode root, List<int> result)
        {
            Stack<TreeNode> items = new Stack<TreeNode>();
            TreeNode current = root;
            while (current != null || items.Count > 0)
            {
                while (current != null)
                {
                    items.Push(current);
                    current = current.left;
                }

                current = items.Pop();

                result.Add(current.val);

                current = current.right;
            }
        }

        static void GetInorderInternal(TreeNode root, List<int> result)
        {
            if (root.left != null)
            {
                GetInorderInternal(root.left, result);
            }

            result.Add(root.val);

            if (root.right != null)
            {
                GetInorderInternal(root.right, result);
            }
        }
    }
}

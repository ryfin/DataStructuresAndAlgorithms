using System;
using System.Collections.Generic;

namespace ValidateBST
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
        public override string ToString()
        {
            return val.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TreeNode root = new TreeNode(val: 10,
                left: new TreeNode(val: 5,
                    left: new TreeNode(val: 3),
                    right: new TreeNode(val: 7)),
                right: new TreeNode(val: 15,
                    left: new TreeNode(9),
                    right: new TreeNode(20)));

            Console.WriteLine(IsValid(root));
        }

        static bool IsValid(TreeNode root)
        {
            return ValidateIterative(root);
        }

        static bool ValidateIterative(TreeNode root)
        {
            Stack<TreeNode> items = new Stack<TreeNode>();
            Stack<int?> mins = new Stack<int?>();
            Stack<int?> maxes = new Stack<int?>();
            mins.Push(null);
            maxes.Push(null);
            items.Push(root);
            while (items.Count > 0)
            {
                TreeNode current = items.Pop();
                int? min = mins.Pop();
                int? max = maxes.Pop();
                if ((max.HasValue && current.val > max.Value) || (min.HasValue && current.val < min.Value))
                {
                    return false;
                }
                if (current.left != null)
                {
                    items.Push(current.left);
                    mins.Push(min);
                    maxes.Push(current.val);
                }
                if (current.right != null)
                {
                    items.Push(current.right);
                    mins.Push(current.val);
                    maxes.Push(max);
                }
            }

            return true;
        }

        static bool Validate(TreeNode root, int? min, int? max)
        {
            if (root == null) return false;

            if ((max.HasValue && root.val > max.Value) || (min.HasValue && root.val < min.Value))
            {
                return false;
            }
            bool isValid = true;
            if (root.left != null)
            {
                isValid &= Validate(root.left, min, root.val);
            }

            if (root.right != null)
            {
                isValid &= Validate(root.right, root.val, max);
            }

            return isValid;
        }
    }
}

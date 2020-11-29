using System;
using System.Collections.Generic;

namespace LevelOrderTraversal
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
            TreeNode root = new TreeNode(val: 1,
                left: new TreeNode(val: 2,
                    left: new TreeNode(val: 4),
                    right: new TreeNode(val: 5)),
                right: new TreeNode(val: 3));
            foreach(var level in GetLevelOrder(root))
            {
                foreach(int item in level)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        static IList<IList<int>> GetLevelOrder(TreeNode root){
            if (root == null) return new List<IList<int>>();
            var result = new List<IList<int>>();
            Queue<TreeNode> items = new Queue<TreeNode>();
            items.Enqueue(root);
            items.Enqueue(new TreeNode(int.MinValue));
            IList<int> currentLevel = new List<int>();
            while(items.Count > 0)
            {
                TreeNode current = items.Dequeue();
                
                if(current.val == int.MinValue)
                {
                    if(items.Count == 0)
                    {
                        result.Add(currentLevel);
                        
                        break;
                    }

                    result.Add(currentLevel);
                    currentLevel = new List<int>();
                    items.Enqueue(new TreeNode(int.MinValue));
                    
                    continue;
                }
                
                currentLevel.Add(current.val);
                if (current.left != null)
                {
                    items.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    items.Enqueue(current.right);
                }
            }

            return result;
        }
    }
}

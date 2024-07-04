using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace binary_tree
{
    internal class BinaryTreeFunctions
    {
        public TreeNode Root { get; set; }

        public void Insert (int key, string value)
        {
            Root = InsertRec(key, value, Root);
        }

        private TreeNode InsertRec (int key, string value, TreeNode root)
        {
            if (root == null)
            {
                root = new TreeNode(key,value);
                return root;
            }

            if (key < root.Key)
            {
                root.Left = InsertRec(key, value, root.Left);
            }
            else if (key > root.Key)
            {
                root.Right = InsertRec(key, value, root.Right); 
            }
            

            root = Balance(root);
            return root;
        }

        public string Search (int key)
        {
            TreeNode result = SearchRec(key, Root);
            if (result != null)
                return result.Value;
            else 
                return null;
        }

        private TreeNode SearchRec (int key, TreeNode root)
        {
            if (root.Key == key || root == null)
            {
                return root;
            }

            if (key < root.Key)
            {
                return SearchRec(key, root.Left);
            }
            else
            {
                return SearchRec(key, root.Right);
            }
        }

        public void Delete (int key)
        {
            Root = DeleteRec(key, Root);
        }

        private TreeNode DeleteRec (int key, TreeNode root)
        {
            if (root == null)
            {
                 return root;
            }
            if (key < root.Key)
            {
                root.Left = DeleteRec(key, root.Left);
            }
            else if (key > root.Key)
            {
                root.Right = DeleteRec(key, root.Right);
            }
            else 
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                root.Key = FindChangeKeyAtDelete(root.Right);
                root.Value = ChangeValueAtDelete(root.Right);
                root.Right = DeleteRec(root.Key,root.Right);
            }

            root = Balance(root);
            return root;
        } 

        private int FindChangeKeyAtDelete(TreeNode root)
        {
            while(root.Left != null)
            {
                root = root.Left;
            }
            return root.Key;
        }

        private string ChangeValueAtDelete(TreeNode root)
        {
            while (root.Left != null)
            {
                root = root.Left;
            }
            return root.Value;
        }

        public void WriteTree()
        {
            WriteTreeRec(Root);
        }

        private void WriteTreeRec(TreeNode root)
        {
            if (root != null)
            {
                WriteTreeRec(root.Left);
                Console.WriteLine($"{root.Key}: {root.Value}");
                WriteTreeRec(root.Right);
            }
        }

        private int Height(TreeNode node)
        {
            if (node == null)
                return 0;
            return Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private int BalanceFactor(TreeNode node)
        {
            if (node == null)
                return 0;
            return Height(node.Left) - Height(node.Right);
        }

        private TreeNode RotateRight(TreeNode y)
        {
            TreeNode x = y.Left;
            TreeNode z = x.Right;

            x.Right = y;
            y.Left = z;

            return x;
        }

        private TreeNode RotateLeft(TreeNode y)
        {
            TreeNode x = y.Right;
            TreeNode z = x.Left;

            x.Left = y;
            y.Right = z;

            return x;
        }

        private TreeNode Balance(TreeNode node)
        {
            int balance = BalanceFactor(node);

            if (balance > 1)
            {
                if (BalanceFactor(node.Left) < 0)
                    node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1)
            {
                if (BalanceFactor(node.Right) > 0)
                    node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void PrintTree()
        {
            int maxLevel = Height(Root);
            PrintTreeKeys(new List<TreeNode> { Root }, 1, maxLevel);
        }

        private void PrintTreeKeys(List<TreeNode> nodes, int level, int maxLevel)
        {
            if (nodes.Count == 0 || IsAllElementsNull(nodes))
                return;

            int floor = maxLevel - level;
            int edgeLines = (int)Math.Pow(2, Math.Max(floor - 1, 0));
            int firstSpaces = (int)Math.Pow(2, floor) - 1;
            int betweenSpaces = (int)Math.Pow(2, floor + 1) - 1;

            PrintWhitespaces(firstSpaces);

            List<TreeNode> newNodes = new List<TreeNode>();
            foreach (TreeNode node in nodes)
            {
                if (node != null)
                {
                    Console.Write($"{node.Key}");
                    newNodes.Add(node.Left);
                    newNodes.Add(node.Right);
                }
                else
                {
                    newNodes.Add(null);
                    newNodes.Add(null);
                    Console.Write(" ");
                }

                PrintWhitespaces(betweenSpaces);
            }
            Console.WriteLine();

            for (int i = 1; i <= edgeLines; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    PrintWhitespaces(firstSpaces - i);
                    if (nodes[j] == null)
                    {
                        PrintWhitespaces(edgeLines + edgeLines + i + 1);
                        continue;
                    }

                    if (nodes[j].Left != null)
                        Console.Write("/");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(i + i - 1);

                    if (nodes[j].Right != null)
                        Console.Write("\\");
                    else
                        PrintWhitespaces(1);

                    PrintWhitespaces(edgeLines + edgeLines - i);
                }
                Console.WriteLine();
            }

            PrintTreeKeys(newNodes, level + 1, maxLevel);
        }

        private void PrintWhitespaces(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write(" ");
        }

        private bool IsAllElementsNull(List<TreeNode> list)
        {
            foreach (var node in list)
            {
                if (node != null)
                    return false;
            }
            return true;
        }
    }
}

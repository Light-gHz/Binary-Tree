using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_tree
{
    internal class TreeNode
    {
        public int Key {  get; set; } 
        public string Value {  get; set; }
        public TreeNode Right { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode(int key, string value)
        {
            Key = key;
            Value = value;
            Right = null;
            Left = null;
        }
    }
}

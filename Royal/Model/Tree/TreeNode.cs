using System;
using System.Collections.Generic;
using System.Text;

namespace Royal.Model
{
    class TreeNode
    {
        private int data;
        int noChildren;
        private TreeNode[] child;
        private TreeNode[] children;
        public int Data { get => data; set => data = value; }
        public int NoChildren { get => noChildren; set => noChildren = value; }
        public TreeNode[] Child { get => child; set => child = value; }
        public TreeNode[] Children { get => children; set => children = value; }

        public TreeNode(int data)
        {
            this.data = data;
            this.noChildren = 0;
        }

        public void copyChildren()
        {
            this.children = new TreeNode[noChildren + 1];
            for (int i = 0; i < this.noChildren; i++)
            {
                children[i] = child[i];
            }
        }

        public void incrementChild(TreeNode node)
        {
            copyChildren();
            children[this.noChildren] = node;
            this.child = children;
            this.noChildren++;
        }

        public void printNode()
        {
            Console.WriteLine("{" + data + "}");
        }
    }
}

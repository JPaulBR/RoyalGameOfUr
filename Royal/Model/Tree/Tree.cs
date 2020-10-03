using System;
using System.Collections.Generic;
using System.Text;

namespace Royal.Model.Tree
{
    class Tree
    {
        public TreeNode root;

        public TreeNode insertRoot(int data)
        {
            root = new TreeNode(data);
            return root;
        }

        public void seeChildren(TreeNode node)
        {
            for (int i = 0; i < node.NoChildren; i++)
            {
                node.Child[i].printNode();
                seeChildren(node.Child[i]);
            }
        }

        public void AddChild(TreeNode pNode, int data, int father)
        {
            TreeNode nNode = new TreeNode(data);
            if (pNode.Data == father)
            {
                pNode.incrementChild(nNode);
            }
            else
            {
                for (int i = 0; i < pNode.NoChildren; i++)
                {
                    if (pNode.Child[i].Data == father)
                    {
                        pNode.Child[i].incrementChild(nNode);
                    }
                    else
                    {
                        AddChild(pNode.Child[i], data, father);
                    }
                }
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using static Royal.Machine;

namespace Royal.Model.Tree
{
    class Tree
    {
        public TreeNode root;

        public TreeNode insertRoot(int data, dataJson containt)
        {
            root = new TreeNode(data, containt);
            return root;
        }

        public void seeChildren(TreeNode node)
        {
            for (int i = 0; i < node.NoChildren; i++)
            {
                //Console.WriteLine(node.Child[i].Data);
                if (node.Child[i].NoChildren > 0)
                {
                    foreach (TreeNode j in node.Child[i].Child)
                    {
                        Console.Write(j.Data + "->");
                    }
                    Console.WriteLine("");
                }
                seeChildren(node.Child[i]);
            }
        }

        public List<TreeNode> childrenList(TreeNode node)
        {
            List<TreeNode> list = new List<TreeNode>();
            foreach (TreeNode i in node.Child)
            {
                list.Add(i);
            }
            foreach (TreeNode j in list)
            {
                Console.Write(j.Data + "->");
            }
            return list;
        }

        public List<int> getLeafs(TreeNode node)
        {
            List<int> id_numbers = new List<int>();
            for (int i = 0; i < node.NoChildren; i++)
            {
                if (node.Child[i].NoChildren == 0)
                {
                    id_numbers.Add(node.Child[i].Data);
                }
                getLeafs(node.Child[i]);
            }
            return id_numbers;
        }

        public void AddChild(TreeNode pNode, int data, int father, dataJson containt)
        {
            TreeNode nNode = new TreeNode(data, containt);
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
                        AddChild(pNode.Child[i], data, father, containt);
                    }
                }
            }
        }

        public static List<dataJson> orderList(List<dataJson> list)
        {
            dataJson temp;
            for (int j = 0; j <= list.Count - 2; j++)
            {
                for (int i = 0; i <= list.Count - 2; i++)
                {
                    if (list[i].root > list[i + 1].root)
                    {
                        temp = list[i + 1];
                        list[i + 1] = list[i];
                        list[i] = temp;
                    }
                }
            }
            /*foreach (dataJson i in list) {
                Console.WriteLine(i.id + " " + i.root+ "pc: "+string.Join(" ",i.array1)+ " human"+ string.Join(" ", i.array2));
            }*/
            return list;
        }

    }
}

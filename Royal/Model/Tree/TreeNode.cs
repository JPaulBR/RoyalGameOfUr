using System;
using System.Collections.Generic;
using System.Text;
using static Royal.Machine;

namespace Royal.Model
{
    class TreeNode
    {
        private int data;
        private int valueUtility;
        private int noChildren;
        private TreeNode[] child;
        private TreeNode[] children;
        private dataJson containt;
        public dataJson ContaintData { get => containt; set => containt = value; }
        public int Value { get => valueUtility; set => valueUtility = value; }
        public int Data { get => data; set => data = value; }
        public int NoChildren { get => noChildren; set => noChildren = value; }
        public TreeNode[] Child { get => child; set => child = value; }

        public TreeNode(int data, dataJson containt)
        {
            this.data = data;
            this.noChildren = 0;
            this.containt = containt;
            this.valueUtility = -1;
        }

        public bool isLeaf(TreeNode node)
        {
            if (node.NoChildren > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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

        public int DicesOnTable(int[] array)
        {
            int cont = 0;
            foreach (int i in array)
            {
                if (i == 1)
                {
                    cont++;
                }
            }
            return cont;
        }

        public int calculateFunction(int initial, int inRow, bool isPc)
        {
            int result = 0;
            int dicesOnTable = DicesOnTable(containt.array2);
            if (isPc)
            {
                dicesOnTable = DicesOnTable(containt.array1);
            }
            result = dicesOnTable - initial + 2 * inRow;
            return result;
        }

        public int getFunctionResult(int initialX, int initialY, int inRowX, int inRowY)
        {
            int human = calculateFunction(initialX, inRowX, false);
            int pc = calculateFunction(initialY, inRowY, true);
            return pc - human;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Royal
{
    class Machine
    {
        public int minimax(int depth, int nodeIndex, bool isMax,
            int[] scores, int h)
        {
            // Terminating condition. i.e leaf node is reached 
            if (depth == h)
                return scores[nodeIndex];

            // If current move is maximizer, find the maximum attainable 
            // value 
            if (isMax)
                return Math.Max(minimax(depth + 1, nodeIndex * 2, false, scores, h),
                        minimax(depth + 1, nodeIndex * 2 + 1, false, scores, h));

            // Else (If current move is Minimizer), find the minimum 
            // attainable value 
            else
                return Math.Min(minimax(depth + 1, nodeIndex * 2, true, scores, h),
                    minimax(depth + 1, nodeIndex * 2 + 1, true, scores, h));
        }

        public int log2(int n)
        {
            return (n == 1) ? 0 : 1 + log2(n / 2);
        }

    }
}

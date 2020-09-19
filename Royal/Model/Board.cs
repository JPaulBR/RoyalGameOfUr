using System;
using System.Collections.Generic;
using System.Text;

namespace Royal.Model
{
    class Board
    {
        int[] b_path = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] w_path = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        int b_token_total;
        int w_token_total;

        public Board()
        {
            b_token_total = 0;
            w_token_total = 0;

        }
    }
}

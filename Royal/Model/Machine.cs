using Royal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        StreamWriter file;

        public void PrintBoard(int[][] board)
        {
            file.WriteLine("#################");
            file.WriteLine("B:  " + string.Join(" ", board[1]) + "\nW: " + string.Join(" ", board[0]));
            file.WriteLine("#################");
        }
        
        public void MakeTree(int [][] board, int player)
        {
            int[] token_total = new int[2];
            int[] token_out = new int[2];
            int[][] token_active = new int[2][];
            token_active[0] = new int[7];
            token_active[1] = new int[7];
            token_active[0] = Enumerable.Repeat(-1, 7).ToArray();
            token_active[1] = Enumerable.Repeat(-1, 7).ToArray();
            StreamWriter f = new StreamWriter(@"D:\Usuarios\gaboq\Escritorio\Gabo\test.txt", true);
            file = f;
            PrintBoard(board);
            MakeTreeAuxiliar(player, board, token_active, token_total, token_out, 1, 1);

        }

        public void MakeTreeAuxiliar(int player, int[][] board, int[][] token_active, int[] token_total, int[] token_out, int level, int id)
        {
            if (CheckWin(player, token_active)) 
            {
                // Condicion terminal
                PrintBoard(board);
            }
            else
            {
                List<int> tokens = Moveable(player, token_active);
                foreach (int token in tokens)
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        if (MoveToken(player, board, token, i, token_active, token_total, token_out))
                        {
                            if (IsRoseta(player, board))
                            {
                                MakeTreeAuxiliar(player, board, token_active, token_total, token_out, level + 1, id);
                            } else
                            {
                                MakeTreeAuxiliar((player == 1 ? 0 : 1), board, token_active, token_total, token_out, level + 1, id);
                            }
                        }
                    }
                }
                for (int i = 1; i <= 4; i++)
                {
                    if (MoveFirstToken(player, board, i, token_active, token_total))
                    {
                        if (IsRoseta(player, board))
                        {
                            MakeTreeAuxiliar(player, board, token_active, token_total, token_out, level + 1, id);
                        }
                        else
                        {
                            MakeTreeAuxiliar((player == 1 ? 0 : 1), board, token_active, token_total, token_out, level + 1, id);
                        }
                    }
                }
            }
        }

        //
        public bool MoveFirstToken(int player, int[][] board, int moves, int[][] token_active, int[] token_total)
        {
            int[] player_token = token_active[player];
            int[] player_board = board[player];
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == -1)
                {
                    if (moves != 0 && player_board[player_token[i] + moves] != 1)
                    {
                        player_board[player_token[i] + moves] = 1;
                        player_token[i] += moves;
                        token_total[player] -= 1;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MoveToken(int player, int[][] board, int token, int moves, int[][] token_active, int[] token_total, int[] token_out)
        {
            int[] player_token = token_active[player];
            int[] player_board = board[player];
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == token)
                {
                    if (token + moves == 15)
                    {
                        player_token[i] = -2;
                        player_board[token] = 0;
                        token_out[player] += 1;
                        return true;
                    }
                    else if (token + moves < 15)
                    {
                        if (player_board[token + moves] != 1)
                        {
                            player_token[i] = token + moves;
                            player_board[token] = 0;
                            player_board[player_token[i]] = 1;
                            CheckRemoveToken(player, board, token, token_total);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<int> Moveable(int player, int[][] token_active)
        {
            List<int> result = new List<int>(); ;
            foreach (int token in token_active[player])
            {
                if (token > -1)
                {
                    result.Add(token);
                }
            }
            return result;
        }

        public bool CheckRemoveToken(int player, int[][] board, int token, int[] token_total)
        {
            int[] opposite_board = player == 1 ? board[0] : board[1]; // Inverted
            if (opposite_board[token] == 1)
            {
                opposite_board[token] = 0;
                token_total[player] += 1;
                return true;
            }
            return false;
        }

        public bool CheckWin(int player, int[][] token_active)
        {
            if (player == 0)
            {
                foreach (int token in token_active[0])
                {
                    if (token != -2)
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (int token in token_active[1])
                {
                    if (token != -2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsRoseta(int player, int[][] board)
        {
            int[] player_board = board[player];
            if (player_board[3] == 1 || player_board[7] == 1 || player_board[11] == 1)
            {
                return true;
            }
            return false;
        }

    }
}

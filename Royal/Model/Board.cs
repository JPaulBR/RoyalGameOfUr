using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Royal.Model
{
    class Board
    {
        private int[] b_path;
        private int[] w_path;
        public int[] BlackPath { get => b_path; }
        public int[] WhitePath { get => w_path; }

        private int b_token_total;
        private int w_token_total;
        public int BlackTotal { get => b_token_total; set => b_token_total = value; }
        public int WhiteTotal { get => w_token_total; set => w_token_total = value; }

        private int b_token_out;
        private int w_token_out;
        public int BlackOut { get => b_token_out; set => b_token_out = value; }
        public int WhiteOut { get => w_token_out; set => w_token_out = value; }

        int[] b_token_active;
        int[] w_token_active;

        int player_turn;


        public int TurnCounter { get => TurnCounter; set => TurnCounter = value; }

        public int PlayerTurn { get => player_turn; set => player_turn = value; }

        public Board(int total = 7)
        {
            b_path = Enumerable.Repeat(0, 15).ToArray();
            w_path = Enumerable.Repeat(0, 15).ToArray();
            //player_turn = new Random().Next(2);
            player_turn = 0;
            b_token_total = total;
            w_token_total = total;
            b_token_out = 0;
            w_token_out = 0;
            b_token_active = Enumerable.Repeat(-1, b_token_total).ToArray();
            w_token_active = Enumerable.Repeat(-1, w_token_total).ToArray();
            TurnCounter = 1;
        }

        public int GetMove(int turn)
        {
            int[] moves = { 1, 2, 3, 3, 2, 4, 2, 2, 1, 3, 1, 1, 4, 1, 1, 1, 3, 4, 1, 3, 1, 2, 1, 1, 1, 3, 2, 2, 2, 2, 2, 1, 2, 2, 3, 2, 1, 4, 2, 3, 3, 4, 1, 2, 2, 3, 2, 3,
                1, 1, 2, 2, 3, 1, 3, 1, 2, 3, 1, 4, 1, 2, 4, 1, 2, 4, 1, 2, 2, 1, 1, 1, 2, 1, 2, 1, 2, 2, 1, 1, 1, 4, 4, 1, 4, 2, 1, 1, 1, 3, 1, 3, 1, 2, 2, 1, 2, 2, 4, 2,
                2, 1, 1, 4, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 1, 2, 2, 4, 1, 3, 1, 1, 4, 1, 2, 1, 1, 2, 1, 2, 4, 1, 2, 3, 2, 1, 1, 2, 1, 4, 1, 1, 2, 1, 1, 1, 3, 1, 1, 2, 1, 4,
                4, 4, 1, 2, 4, 4, 1, 3, 1, 2, 1, 4, 4, 1, 2, 1, 2, 2, 2, 4, 1, 2, 3, 2, 2, 1, 2, 2, 1, 3, 1, 3, 1, 2, 3, 3, 1, 3, 2, 2, 3, 2, 1, 4, 1, 3, 1, 2, 2, 3, 3, 2,
                1, 2, 2, 1, 1, 1, 2, 1, 2, 1, 4, 4, 1, 4, 2, 1, 2, 3, 2, 2, 4, 2, 1, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 2, 2, 3, 2, 1, 2, 1, 1, 1, 3, 2, 2, 1, 1, 2, 2, 2, 1, 2,
                3, 1, 4, 1, 2, 4, 2, 4, 3, 2, 1, 2, 3, 1, 1, 2, 2, 2, 3, 1, 3, 1, 4, 2, 3, 1, 1, 2, 2, 2, 1, 1, 2, 2, 2, 1, 2, 2, 2, 3, 2, 3, 2, 2 };
            return moves[turn - 1];
        }
        
        public void PrintBoard()
        {
            MessageBox.Show("B:  " + string.Join(" ", b_path) + "\nW: " + string.Join(" ", w_path));
        }

        /* Busca las fichas que se pueden mover por jugador
         * Recive: int para indicar el jugador: 0 white 1 black
         * Retorna: lista con los indices de las fichas que se pueden mover
         */
        public List<int> Moveable(int player)
        {
            List<int> result = new List<int>(); ;
            foreach(int token in (player == 1 ? b_token_active : w_token_active) )
            {
                if (token > -1)
                {
                    result.Add(token);
                }
            }
            return result;
        }

        public bool MoveFirstToken(int player, int moves)
        {
            int[] player_token = player == 1 ? b_token_active : w_token_active;
            int[] player_board = player == 1 ? b_path : w_path;
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == -1)
                {
                    if (player_board[player_token[i] + moves] != 1)
                    {
                        player_board[player_token[i] + moves] = 1;
                        player_token[i] += moves;
                        if (player == 0)
                        {
                            w_token_total -= 1;
                        }
                        else
                        {
                            b_token_total -= 1;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        /* Mueve una ficha
         * Recive: int 0 white 1 black, int posicion antes de mover, int cantidad a mover
         * Retorna: true si el movimiento es valido
         */
        public bool MoveToken(int player, int token, int moves)
        {
            int[] player_token = player == 1 ? b_token_active : w_token_active;
            int[] player_board = player == 1 ? b_path : w_path;
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == token)
                {
                    int token_moved = token + moves;
                    if (token_moved == 14)
                    {
                        player_token[i] = -2;
                        player_board[token] = 0;
                        if (player == 0)
                        {
                            w_token_out += 1;
                        }
                        else
                        {
                            b_token_out += 1;
                        }
                        return true;
                    } else if (token_moved < 14)
                    {
                        if (player_board[token_moved] != 1)
                        {
                            if (!IsRoseta((player == 1 ? 0 : 1), token_moved))
                            {
                                player_token[i] = token_moved;
                                player_board[token] = 0;
                                player_board[token_moved] = 1;
                                CheckRemoveToken(player, player_token[i]);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /* Verifica si la jugada elimina una ficha
         * Recive: int 0 white 1 black, int posicion de la ficha
         * Retorna: true si elimina una ficha
         */
        public bool CheckRemoveToken(int player, int token)
        {
            int[] player_token = player == 1 ? w_token_active : b_token_active; //token_active[(player == 1 ? 0 : 1)];
            int[] opposite_board = player == 1 ? w_path : b_path; // Inverted
            if (opposite_board[token] == 1)
            {
                player_token[Array.IndexOf(player_token, token)] = -1;
                opposite_board[token] = 0;
                if (player == 0)
                {
                    b_token_total += 1;
                } else
                {
                    w_token_total += 1;
                }
                return true;
            }
            return false;
        }

        public bool CheckWin(int player)
        {
            if (player == 0)
            {
                foreach (int token in w_token_active)
                {
                    if (token != -2)
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (int token in b_token_active)
                {
                    if (token != -2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsRoseta(int player)
        {
            int[] player_board = player == 1 ? b_path : w_path;
            if (player_board[3] == 1 || player_board[7] == 1 || player_board[11] == 1)
            {
                return true;
            }
            return false;
        }

        private bool IsRoseta(int player, int token)
        {
            int[] player_board = player == 1 ? b_path : w_path;
            if (token == 3 || token == 7 || token == 13)
            {
                if (player_board[token] == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public int ChangeTurn() //talvez hay que cambiar esto
        {
            TurnCounter++;
            if (IsRoseta(player_turn))
            {
                return player_turn;
            }
            player_turn = player_turn == 1 ? 0 : 1;
            return player_turn;
        }

    }
}

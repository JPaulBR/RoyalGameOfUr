using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace Royal.Model
{
    class Board
    {
        int[] b_path;
        int[] w_path;

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
        public int PlayerTurn { get => player_turn; set => player_turn = value; }

        public Board(int total = 7)
        {
            b_path = Enumerable.Repeat(0, 14).ToArray();
            w_path = Enumerable.Repeat(0, 14).ToArray();
            player_turn = new Random().Next(2);
            b_token_total = total;
            w_token_total = total;
            b_token_out = 0;
            w_token_out = 0;
            b_token_active = Enumerable.Repeat(-1, b_token_total).ToArray();
            w_token_active = Enumerable.Repeat(-1, w_token_total).ToArray();
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
            int player_total_token = player == 1 ? b_token_total : w_token_total;
            int[] player_board = player == 1 ? b_path : w_path;
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == -1)
                {
                    if (moves != 0 && player_board[player_token[i] + moves] != 1)
                    {
                        player_board[player_token[i] + moves] = 1;
                        player_token[i] += moves;
                        player_total_token -= 1;
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

                    if (token + moves < player_board.Length  && player_board[token + moves] != 1)
                    {
                        player_token[i] = token + moves;
                        player_board[token] = 0;
                        player_board[player_token[i]] = 1;
                        CheckRemoveToken(player, player_token[i]);
                        return true;
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
            int[] opposite_board = player == 1 ? w_path : b_path;
            int player_total_token = player == 1 ? w_token_total : b_token_total;
            if (opposite_board[token] == 1)
            {
                opposite_board[token] = 0;
                player_total_token++;
                return true;
            }
            return false;
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
    }
}

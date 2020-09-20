using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Royal.Model
{
    class Board
    {
        int[] b_path = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] w_path = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        int b_token_total;
        int w_token_total;
        int[] b_token_active;
        int[] w_token_active;


        public Board(int total = 7)
        {
            b_token_total = total;
            w_token_total = total;
            b_token_active = Enumerable.Repeat(-1, b_token_total).ToArray();
            w_token_active = Enumerable.Repeat(-1, w_token_total).ToArray();
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
                    if (player_board[token + moves] != 1 && token + moves < player_board.Length)
                    {
                        player_token[i] = token + moves;
                        player_board[token] = 0;
                        player_board[player_token[i]] = 1;
                        CheckRemoveToken(player, player_token[i]);
                        return true;
                    }
                    return false;
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
            if (opposite_board[token] == 1)
            {
                opposite_board[token] = 0;
                return true;
            }
            return false;
        }
    }
}

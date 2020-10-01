﻿using Royal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                // Terminal conditional
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

        public List<dataJson> LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Jean Paul\Desktop\jsonfile.json"))
            {
                string json = r.ReadToEnd();
                List<dataJson> items = JsonConvert.DeserializeObject<List<dataJson>>(json);
                return items;
            }
        }

        public void WriteInJson(int id,int[] arr1,int[] arr2,int root,int level) {
            List<dataJson> items = LoadJson();
            if (items == null) {
                items = new List<dataJson>();
            }
            items.Add(new dataJson()
            {
                id = id,
                array1 = arr1,
                array2 = arr2,
                root = root,
                level = level
            });
            //open file stream
            using (StreamWriter file = File.CreateText(@"C:\Users\Jean Paul\Desktop\jsonfile.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, items);
            }
        }

        public class dataJson {
            
            public int id { get; set; }
            public int[] array1 { get; set; }
            public int[] array2 { get; set; }
            public int root { get; set; }
            public int level { get; set; }

            /*private int id;
            private int[] array1 = new int [15];
            private int[] array2 = new int[15];
            private int root;
            private int level;

            public dataJson(int id,int[] array1,int[] array2,int root,int level) {
                this.id = id;
                this.array1 = array1;
                this.array2 = array2;
                this.root = root;
                this.level = level;
            }

            public int getId() {
                return this.id;
            }

            public int[] getArray1() {
                return this.array1;
            }*/
        }

    }
}

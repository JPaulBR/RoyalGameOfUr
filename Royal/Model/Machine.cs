using Royal.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

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


        private void PrintBoard(int[][] board, int level, int player)
        {
            Console.WriteLine("#################");
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Player: " + player);
            Console.WriteLine("B: " + string.Join(" ", board[1]) + "\nW: " + string.Join(" ", board[0]));
            Console.WriteLine("#################");
            WriteInJson(level, board[1], board[0], player, level);
        }

        public void MakeTree(int[][] board, int player)
        {
            int[] token_total = { 7, 7 };
            int[] token_out = { 0, 0 };
            int[][] token_active = new int[2][];
            token_active[0] = new int[7];
            token_active[1] = new int[7];
            token_active[0] = Enumerable.Repeat(-1, 7).ToArray();
            token_active[1] = Enumerable.Repeat(-1, 7).ToArray();
            MakeTreeAuxiliar(player, board, token_active, token_total, token_out, 1, 1);
        }

        private void MakeTreeAuxiliar(int player, int[][] board, int[][] token_active, int[] token_total, int[] token_out, int level, int id)
        {
            Random rnd = new Random();
            List<int> iter1 = new List<int>();
            iter1.Add(0); iter1.Add(1);
            List<int> iter2 = new List<int>();
            List<int> iter3 = new List<int>();
            for (int e = 0; e <= 1; e++)
            {
                int count = rnd.Next(iter1.Count);
                int rand1 = iter1.ElementAt(count);
                iter1.RemoveAt(count);
                switch (rand1)
                {
                    case 1:
                        List<int> tokens = Moveable(player, token_active);
                        foreach (int token in tokens)
                        {
                            iter2.Add(1); iter2.Add(2); iter2.Add(3); iter2.Add(4);
                            for (int i = 1; i <= 4; i++)
                            {
                                int count2 = rnd.Next(iter2.Count);
                                int rand2 = iter2.ElementAt(count2);
                                iter2.RemoveAt(count2);
                                bool replay = false;

                                int[][] copy = new int[2][];
                                copy[0] = new int[15]; copy[1] = new int[15];
                                Array.Copy(board[0], copy[0], 15);
                                Array.Copy(board[1], copy[1], 15);

                                if (MoveToken(player, copy, token, rand2, token_active, token_total, token_out, replay))
                                {
                                    if (CheckWin(player, token_active))
                                    {
                                        // Condicion terminal
                                        Console.WriteLine("++++++++ WINNER +++++++");
                                        PrintBoard(copy, level, player);
                                        return;
                                    }
                                    PrintBoard(copy, level, player);
                                    if (replay) ///////
                                    {
                                        MakeTreeAuxiliar(player, copy, token_active, token_total, token_out, level + 1, id + 1);
                                    }
                                    else
                                    {
                                        MakeTreeAuxiliar((player == 1 ? 0 : 1), copy, token_active, token_total, token_out, level + 1, id + 1);
                                    }
                                }
                            }
                        }
                        break;
                    case 0:
                        iter3.Add(1); iter3.Add(2); iter3.Add(3); iter3.Add(4);
                        for (int i = 1; i <= 4; i++)
                        {
                            int count2 = rnd.Next(iter3.Count);
                            int rand2 = iter3.ElementAt(count2);
                            iter3.RemoveAt(count2);

                            int[][] copy = new int[2][];
                            copy[0] = new int[15]; copy[1] = new int[15];
                            Array.Copy(board[0], copy[0], 15);
                            Array.Copy(board[1], copy[1], 15);

                            if (MoveFirstToken(player, copy, rand2, token_active, token_total))
                            {
                                if (CheckWin(player, token_active))
                                {
                                    // Condicion terminal
                                    Console.WriteLine("+++++++++++++++");
                                    PrintBoard(copy, level, player);
                                    return;
                                }
                                PrintBoard(copy, level, player);
                                if (rand2 == 4)
                                {
                                    MakeTreeAuxiliar(player, copy, token_active, token_total, token_out, level + 1, id + 1);
                                }
                                else
                                {
                                    MakeTreeAuxiliar((player == 1 ? 0 : 1), copy, token_active, token_total, token_out, level + 1, id + 1);
                                }
                            }
                        }
                        break;
                }
            }
        }

        //
        private bool MoveFirstToken(int player, int[][] board, int moves, int[][] token_active, int[] token_total)
        {
            int[] player_token = token_active[player];
            int[] player_board = board[player];
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == -1)
                {
                    if (player_board[player_token[i] + moves] != 1)
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

        private bool MoveToken(int player, int[][] board, int token, int moves, int[][] token_active, int[] token_total, int[] token_out, bool replay)
        {
            int[] player_token = token_active[player];
            int[] player_board = board[player];
            replay = false;
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == token)
                {
                    int token_moved = token + moves;
                    if (token_moved == 15)
                    {
                        player_token[i] = -2;
                        player_board[token] = 0;
                        token_out[player] += 1;
                        return true;
                    }
                    else if (token_moved < 15)
                    {
                        if (player_board[token_moved] != 1)
                        {
                            if (!IsRoseta((player == 1 ? 0 : 1), board, token_moved))
                            {
                                player_token[i] = token_moved;
                                player_board[token] = 0;
                                player_board[token_moved] = 1;
                                CheckRemoveToken(player, board, token_moved, token_total, token_active);
                                if (IsRoseta(player, board, token_moved))
                                    replay = true;
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private List<int> Moveable(int player, int[][] token_active)
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

        private bool CheckRemoveToken(int player, int[][] board, int token, int[] token_total, int[][] token_active)
        {
            int[] player_token = token_active[player];
            int[] opposite_board = player == 1 ? board[0] : board[1]; // Inverted
            if (token > 3 && token != 8 && token != 12)
            {
                if (opposite_board[token] == 1)
                {
                    player_token[Array.IndexOf(player_token, token)] = 0;
                    opposite_board[token] = 0;
                    token_total[player] += 1;
                    return true;
                }
            }
            return false;
        }

        private bool CheckWin(int player, int[][] token_active)
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

        private bool IsRoseta(int player, int[][] board, int token)
        {
            int[] player_board = board[player];
            if (token == 3 || token == 7 || token == 13)
            {
                if (player_board[token] == 1)
                {
                    return true;
                }
            }
            return false;
        }


        public List<dataJson> LoadJson()
        {
            using (StreamReader r = new StreamReader(@"D:\Usuarios\gaboq\Escritorio\Gabo\jsonfile.json"))
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
            using (StreamWriter file = File.CreateText(@"D:\Usuarios\gaboq\Escritorio\Gabo\jsonfile.json"))
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

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
using Royal.Model.Tree;
using System.Media;

namespace Royal
{
    class Machine
    {

        public int Calcminimax(Tree desitionTree, int turn)
        {
            return Minimax(desitionTree.root, (turn==0?true:false));
        }

        private int Minimax(Model.TreeNode node, bool isMax)
        {
            if (node.isLeaf(node))
            {
                return node.getFunctionResult(node.ContaintData.initialH, node.ContaintData.initialM, node.ContaintData.finalH, node.ContaintData.finalM);
            }
            switch(node.Child.Length)
            {
                case 1:
                    if (isMax) {
                        node.Value = Math.Max(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false), -8);
                    } else {
                        node.Value = Math.Min(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false), 15);
                    }
                    return node.Value;
                case 2:
                    if (isMax) {
                        node.Value = Math.Max(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false));
                    } else {
                        node.Value = Math.Min(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false));
                    }
                    return node.Value;
                case 3:
                    if (isMax) {
                        node.Value = Math.Max(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false)));

                    } else {
                        node.Value = Math.Min(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false)));
                    }
                    return node.Value;
                case 4:
                    if (isMax) { 
                        node.Value = Math.Max(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false))));
                    } else {
                        node.Value = Math.Min(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false))));
                    }
                    return node.Value;
                case 5:
                    if (isMax) {
                        node.Value = Math.Max(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[4], node.Child[4].ContaintData.playerTurn == 0 ? true : false)))));
                    } else {
                        node.Value = Math.Min(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[4], node.Child[4].ContaintData.playerTurn == 0 ? true : false)))));
                    }
                    return node.Value;
                case 6:
                    if (isMax) {
                        node.Value = Math.Max(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[4], node.Child[4].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[5], node.Child[5].ContaintData.playerTurn == 0 ? true : false))))));
                    } else {
                        node.Value = Math.Min(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[4], node.Child[4].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[5], node.Child[5].ContaintData.playerTurn == 0 ? true : false))))));
                    }
                    return node.Value;
                default:
                    if (isMax) {
                        node.Value = Math.Max(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[4], node.Child[4].ContaintData.playerTurn == 0 ? true : false),
                            Math.Max(Minimax(node.Child[5], node.Child[5].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[6], node.Child[6].ContaintData.playerTurn == 0 ? true : false)))))));
                    } else {
                        node.Value = Math.Min(Minimax(node.Child[0], node.Child[0].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[1], node.Child[1].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[2], node.Child[2].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[3], node.Child[3].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[4], node.Child[4].ContaintData.playerTurn == 0 ? true : false),
                            Math.Min(Minimax(node.Child[5], node.Child[5].ContaintData.playerTurn == 0 ? true : false),
                            Minimax(node.Child[6], node.Child[6].ContaintData.playerTurn == 0 ? true : false)))))));
                    }
                    return node.Value;
            }
        }


        /******************/
        int id;
        int[] turnos;
        int[] dados;

        private void PrintBoard(int[][] board, int player, int[][] token_active, int[] token_total, int[] token_out, int level, int idnum, int root)
        {
            Console.WriteLine("#################");
            Console.WriteLine("ID: " + idnum);
            Console.WriteLine("Root: " + root);
            Console.WriteLine("Level: " + level);
            Console.WriteLine("Player: " + player);
            Console.WriteLine("W: " + string.Join(" ", board[0]) + "\nB: " + string.Join(" ", board[1]));
            Console.WriteLine("W: " + string.Join(" ", token_active[0]) + "\nB: " + string.Join(" ", token_active[1]));
            Console.WriteLine("TOTAL:   W: " + token_total[0] + " B: " + token_total[1]);
            Console.WriteLine("OUT:     W: " + token_out[0] + " B: " + token_out[1]);
            Console.WriteLine("#################");
            WriteInJson(idnum, board[0], board[1], root, level, token_total[player], token_out[player], token_total[(player==1?0:1)], token_out[(player == 1 ? 0 : 1)], player);
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

            RandomGenerator random = new RandomGenerator();
            int t = 300;
            turnos = new int[t];
            dados = new int[t];
            for (int i = 1; i <= t; i++)
            {
                turnos[i - 1] = i;
                int moves = random.Next(0, 2) + random.Next(0, 2) + random.Next(0, 2);
                if (moves == 0)
                {
                    dados[i - 1] = 4;
                }
                else
                {
                    dados[i - 1] = moves;
                }
            }
            using (StreamWriter file = File.CreateText(@"D:\Usuarios\gaboq\Escritorio\Gabo\dados.txt"))
            {
                file.WriteLine(string.Join(" ", dados));
            }

            id = 0;
            MakeTreeAuxiliar(player, board, token_active, token_total, token_out, 1, id, 0);

            Console.WriteLine(string.Join(" ", dados));

        }

        private void MakeTreeAuxiliar(int player, int[][] board, int[][] token_active, int[] token_total, int[] token_out, int level, int idnum, int root)
        {
            PrintBoard(board, player, token_active, token_total, token_out, level, idnum, root);
            int new_root = idnum;
            if (CheckWin(player, token_active))
            {
                // Condicion terminal
                Console.WriteLine("++++++++ WINNER +++++++\n");
                return;
            }
            int[][] copy = new int[2][]; copy[0] = new int[15]; copy[1] = new int[15];
            Array.Copy(board[0], copy[0], 15); Array.Copy(board[1], copy[1], 15);
            int[][] copy_token_active = new int[2][]; copy_token_active[0] = new int[7]; copy_token_active[1] = new int[7];
            Array.Copy(token_active[0], copy_token_active[0], 7); Array.Copy(token_active[1], copy_token_active[1], 7);
            int[] copy_token_total = new int[2];
            Array.Copy(token_total, copy_token_total, 2);
            int[] copy_token_out = new int[2];
            Array.Copy(token_out, copy_token_out, 2);

            List<int> tokens = Moveable(player, token_active);
            foreach (int token in tokens)
            {
                bool[] replay = new bool[1];
                if (MoveToken(player, copy, token, dados[level - 1], copy_token_active, copy_token_total, copy_token_out, replay))
                {
                    //PrintBoard(copy, player, token_active, token_total, token_out, level, idnum, root);
                    if (replay[0]) ///////
                    {
                        this.id++;
                        MakeTreeAuxiliar(player, copy, copy_token_active, copy_token_total, copy_token_out, level + 1, id, new_root);
                    }
                    else
                    {
                        this.id++;
                        MakeTreeAuxiliar((player == 1 ? 0 : 1), copy, copy_token_active, copy_token_total, copy_token_out, level + 1, id, new_root);
                    }
                }
            }
            if (MoveFirstToken(player, copy, dados[level - 1], copy_token_active, copy_token_total))
            {
                //PrintBoard(copy, player, token_active, token_total, token_out, level, idnum, root);
                if (dados[level - 1] == 4)
                {
                    this.id++;
                    MakeTreeAuxiliar(player, copy, copy_token_active, copy_token_total, copy_token_out, level + 1, id, new_root);
                }
                else
                {
                    this.id++;
                    MakeTreeAuxiliar((player == 1 ? 0 : 1), copy, copy_token_active, copy_token_total, copy_token_out, level + 1, id, new_root);
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

        private bool MoveToken(int player, int[][] board, int token, int moves, int[][] token_active, int[] token_total, int[] token_out, bool[] replay)
        {
            int[] player_token = token_active[player];
            int[] player_board = board[player];
            replay[0] = false;
            for (int i = 0; i < player_token.Length; i++)
            {
                if (player_token[i] == token)
                {
                    int token_moved = token + moves;
                    if (token_moved == 14)
                    {
                        player_token[i] = -2;
                        player_board[token] = 0;
                        token_out[player] += 1;
                        return true;
                    }
                    else if (token_moved < 14)
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
                                    replay[0] = true;
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
            int[] player_token = token_active[(player == 1 ? 0 : 1)];
            int[] opposite_board = player == 1 ? board[0] : board[1]; // Inverted
            if (token > 3 && token != 8 && token != 12)
            {
                if (opposite_board[token] == 1)
                {
                    player_token[Array.IndexOf(player_token, token)] = -1;
                    opposite_board[token] = 0;
                    token_total[(player == 1 ? 0 : 1)] += 1;
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
            //using (StreamReader r = new StreamReader(@"C:\Users\Jean Paul\Downloads\jsonfileA.json"))
            using (StreamReader r = new StreamReader(@"D:\Usuarios\gaboq\Escritorio\Gabo\jsonfile.json"))
            {
                string json = r.ReadToEnd();
                List<dataJson> items = JsonConvert.DeserializeObject<List<dataJson>>(json);
                return items;
            }
        }

        public void WriteInJson(int id,int[] arr1,int[] arr2,int root,int level, int initialh, int finalh, int initialm, int finalm, int player) {
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
                level = level,
                initialH = initialh,
                finalH = finalh,
                initialM = initialm,
                finalM = finalm,
                playerTurn = player
            });
            //open file stream
            using (StreamWriter file = File.CreateText(@"C:\Users\Jean Paul\Downloads\jsonfileA.json"))
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
            public int playerTurn { get; set; }
            public int initialH { get; set; }
            public int initialM { get; set; }
            public int finalH { get; set; }
            public int finalM { get; set; }

        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
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

        //Borrar (es solo por si se necesita)
        public void createJson() {
            List<dataJson> listJson = new List<dataJson>();
            int[] list = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            listJson.Add(new dataJson(1, list, list, 1, 1));
            listJson.Add(new dataJson(2, list, list, 2, 2));
            listJson.Add(new dataJson(3, list, list, 3, 3));
            string json_data = JsonConvert.SerializeObject(listJson[0]);
            JObject json_object = JObject.Parse(json_data);
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Jean Paul\Desktop\jsonfile.json"))
            {
                string json = r.ReadToEnd();
                List<dataJson> items = JsonConvert.DeserializeObject<List<dataJson>>(json);
            }
        }



        public class dataJson {
            int id;
            int[] array1 = new int [15];
            int[] array2 = new int[15];
            int root;
            int level;

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
            }
        }

    }
}

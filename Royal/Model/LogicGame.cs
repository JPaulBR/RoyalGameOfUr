using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Royal.Model
{
    class LogicGame
    {
        private Image chip1A = Properties.Resources.dado1;
        private Image chip2A = Properties.Resources.dado2;
        private Image chip3A = Properties.Resources.dado3;
        private Image chip4A = Properties.Resources.dado4;
        private Image chip5A = Properties.Resources.dado5;
        private Image chip6A = Properties.Resources.dado6;
        private int[] stepsCount = new int[4];
        private Image[] newList = new Image[4];
        private Token[] tokensPc = new Token[15];
        private Token[] tokensHuman = new Token[15];

        public LogicGame() { 
        }


        /*This function is for shuffle chips, returns an image array for the buttons*/
        public Image[] throwChips()
        {
            Image[] imageList = { chip1A, chip2A, chip3A, chip4A, chip5A, chip6A };
            Random random = new Random();
            int a = random.Next(1, 6);
            int b = random.Next(1, 6);
            int c = random.Next(1, 6);
            this.newList[0] = imageList[a];
            this.newList[1] = imageList[b];
            this.newList[2] = imageList[c];
            this.stepsCount[0] = a;
            this.stepsCount[1] = b;
            this.stepsCount[2] = c;
            return newList;
        }

        /*This function returns the amount of spaces that the chips advance*/
        public int getStepsCount() {
            int i = 0;
            foreach (int element in this.stepsCount) {
                if (element==2 || element==4 || element==6) {
                    i++;
                }
            }
            return i;
        }

        public Token[] genetareTokenPc() {
            this.tokensPc[0] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture1);
            this.tokensPc[1] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensPc[2] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture1);
            this.tokensPc[3] = new Token("Pc", false, true, Color.Black, Properties.Resources.Roseta);
            this.tokensPc[4] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture3);
            this.tokensPc[5] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensPc[6] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture4);
            this.tokensPc[7] = new Token("Pc", false, true, Color.Black, Properties.Resources.Roseta);
            this.tokensPc[8] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensPc[9] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture4);
            this.tokensPc[10] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture1);
            this.tokensPc[11] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensPc[12] = new Token("Pc", false, false, Color.Black, Properties.Resources.Picture5);
            this.tokensPc[13] = new Token("Pc", false, true, Color.Black, Properties.Resources.Roseta);
            this.tokensPc[14] = new Token("Pc", false, false, Color.Transparent, null);
            return this.tokensPc;
        }

        public Token[] genetareTokenHuman()
        {
            this.tokensHuman[0] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture1);
            this.tokensHuman[1] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensHuman[2] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture1);
            this.tokensHuman[3] = new Token("Human", false, true, Color.Black, Properties.Resources.Roseta);
            this.tokensHuman[4] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture3);
            this.tokensHuman[5] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensHuman[6] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture4);
            this.tokensHuman[7] = new Token("Human", false, true, Color.Black, Properties.Resources.Roseta);
            this.tokensHuman[8] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensHuman[9] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture4);
            this.tokensHuman[10] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture1);
            this.tokensHuman[11] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture2);
            this.tokensHuman[12] = new Token("Human", false, false, Color.Black, Properties.Resources.Picture5);
            this.tokensHuman[13] = new Token("Human", false, true, Color.Black, Properties.Resources.Roseta);
            this.tokensHuman[14] = new Token("Human", false, false, Color.Transparent, null);
            return this.tokensHuman;
        }
    }
}

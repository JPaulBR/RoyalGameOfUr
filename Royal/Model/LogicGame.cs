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
            int d = random.Next(1, 6);
            this.newList[0] = imageList[a];
            this.newList[1] = imageList[b];
            this.newList[2] = imageList[c];
            this.newList[3] = imageList[d];
            this.stepsCount[0] = a;
            this.stepsCount[1] = b;
            this.stepsCount[2] = c;
            this.stepsCount[3] = d;
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
    }
}

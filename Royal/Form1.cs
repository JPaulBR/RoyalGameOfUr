using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Royal
{
    public partial class Form1 : Form
    {
        private Image chip1A = Properties.Resources.dado1;
        private Image chip2A = Properties.Resources.dado2;
        private Image chip3A = Properties.Resources.dado3;
        private Image chip4A = Properties.Resources.dado4;
        private Image chip5A = Properties.Resources.dado5;
        private Image chip6A = Properties.Resources.dado6;
        private Boolean flag = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void principalPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.chip4.BackgroundImage = this.chip4A;
            this.numberHumanChip.Visible = false;
            this.numberPcChip.Visible = false;
            this.ChipHumanB.Visible = false;
            this.ChipPcB.Visible = false;

        }


        /*This function is for shuffle chips*/
        public void throwChips(string user) {
            Image[] imageList = {this.chip1A,this.chip2A,this.chip3A,this.chip4A,this.chip5A,this.chip6A};
            int i = 0;
            Random random = new Random();
            while (i < 10) {
                this.chip1.BackgroundImage = imageList[random.Next(1, 6)];
                this.chip2.BackgroundImage = imageList[random.Next(1, 6)];
                this.chip3.BackgroundImage = imageList[random.Next(1, 6)];
                this.chip4.BackgroundImage = imageList[random.Next(1, 6)];
                System.Threading.Thread.Sleep(100);
                i++;
            }
        }

        private void throwButton_Click(object sender, EventArgs e)
        {
            //this.throwButton.Enabled = false;
            this.throwButton.BackColor = Color.Gray;
            this.throwButton.BackgroundImage = Properties.Resources.swap;
            throwChips("human");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                this.buttonA.BackgroundImage = null;
                this.buttonA.BackColor = Color.Red;
                flag = false;
            }
            else {
                this.buttonA.BackgroundImage = Properties.Resources.Picture1;
                this.buttonA.BackColor = Color.Black;
                flag = true;
            }
            //System.Threading.Thread.Sleep(500);
            //this.buttonA.BackgroundImage = Properties.Resources.Picture1;
        }
    }
}

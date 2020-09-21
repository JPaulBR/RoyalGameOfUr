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
using Royal.Controller;
using Royal.Model;


namespace Royal
{
    public partial class Form1 : Form
    {
        private LogicController logicController;
        private LogicGame logicGame;

        public Form1()
        {
            logicController = new LogicController();
            logicGame = new LogicGame();
            InitializeComponent();
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
            }
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
            
        }



        private void throwButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }
    }
}

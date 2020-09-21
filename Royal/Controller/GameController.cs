using Royal.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Royal.Controller
{
    class GameController
    {
        private Board logic_board;
        private Form1 board;
        private LogicGame logicGame;

        public Form1 GameForm { get => board; set => board= value; }

        public GameController()
        {
            board = new Form1();
            logicGame = new LogicGame();
            init();
            logic_board = new Board();

        }

        public void init()
        {
            this.board.button4.Click += new System.EventHandler(this.buttonBlack0_Click);
            this.board.button3.Click += new System.EventHandler(this.buttonBlack1_Click);
            this.board.button2.Click += new System.EventHandler(this.buttonBlack2_Click);
            this.board.button1.Click += new System.EventHandler(this.buttonBlack3_Click);
            this.board.button8.Click += new System.EventHandler(this.buttonBlack4_Click);
            this.board.button7.Click += new System.EventHandler(this.buttonBlack5_Click);
            this.board.button22.Click += new System.EventHandler(this.buttonWhite0_Click);
            this.board.button21.Click += new System.EventHandler(this.buttonWhite1_Click);
            this.board.button20.Click += new System.EventHandler(this.buttonWhite2_Click);
            this.board.button19.Click += new System.EventHandler(this.buttonWhite3_Click);
            this.board.button16.Click += new System.EventHandler(this.buttonWhite4_Click);
            this.board.button15.Click += new System.EventHandler(this.buttonWhite5_Click);
            this.board.button10.Click += new System.EventHandler(this.buttonCenter0_Click);
            this.board.button9.Click += new System.EventHandler(this.buttonCenter1_Click);
            this.board.button6.Click += new System.EventHandler(this.buttonCenter2_Click);
            this.board.button5.Click += new System.EventHandler(this.buttonCenter3_Click);
            this.board.button12.Click += new System.EventHandler(this.buttonCenter4_Click);
            this.board.button11.Click += new System.EventHandler(this.buttonCenter5_Click);
            this.board.button14.Click += new System.EventHandler(this.buttonCenter6_Click);
            this.board.button13.Click += new System.EventHandler(this.buttonCenter7_Click);
            this.board.throwButton.Click += new System.EventHandler(this.throwButton_Click);
        }

        public void throwButton_Click(object sender, EventArgs e)
        {
            Image[] resultList;
            int i = 0;
            while (i < 1) {
                resultList=logicGame.throwChips();
                this.board.chip1.BackgroundImage = resultList[0];
                this.board.chip2.BackgroundImage = resultList[1];
                this.board.chip3.BackgroundImage = resultList[2];
                this.board.chip4.BackgroundImage = resultList[3];
                Thread.Sleep(500);
                i++;
            }
            MessageBox.Show("Avanza " + logicGame.getStepsCount());
            
        }

        public void buttonBlack0_Click(object sender, EventArgs e)
        {
            // b_path 0
            updateCount();
            
        }

        public void buttonBlack1_Click(object sender, EventArgs e)
        {
            // b_path 1
        }

        public void buttonBlack2_Click(object sender, EventArgs e)
        {
            // b_path 2
        }

        public void buttonBlack3_Click(object sender, EventArgs e)
        {
            // b_path 3
        }

        public void buttonBlack4_Click(object sender, EventArgs e)
        {
            // b_path 12
        }

        public void buttonBlack5_Click(object sender, EventArgs e)
        {
            // b_path 13
        }

        public void buttonWhite0_Click(object sender, EventArgs e)
        {
            // w_path 0
        }

        public void buttonWhite1_Click(object sender, EventArgs e)
        {
            // w_path 1
        }

        public void buttonWhite2_Click(object sender, EventArgs e)
        {
            // w_path 2
        }

        public void buttonWhite3_Click(object sender, EventArgs e)
        {
            // w_path 3
        }

        public void buttonWhite4_Click(object sender, EventArgs e)
        {
            // w_path 12
        }

        public void buttonWhite5_Click(object sender, EventArgs e)
        {
            // w_path 13
        }

        public void buttonCenter0_Click(object sender, EventArgs e)
        {
            // b_path & w_path 4
        }

        public void buttonCenter1_Click(object sender, EventArgs e)
        {
            // b_path & w_path 5
        }

        public void buttonCenter2_Click(object sender, EventArgs e)
        {
            // b_path & w_path 6
        }

        public void buttonCenter3_Click(object sender, EventArgs e)
        {
            // b_path & w_path 7
        }

        public void buttonCenter4_Click(object sender, EventArgs e)
        {
            // b_path & w_path 8
        }

        public void buttonCenter5_Click(object sender, EventArgs e)
        {
            // b_path & w_path 9
        }

        public void buttonCenter6_Click(object sender, EventArgs e)
        {
            // w_path & w_path 10
        }

        public void buttonCenter7_Click(object sender, EventArgs e)
        {
            // w_path & w_path 11
        }

        public void updateCount()
        {
            board.label1.Invoke(new Action(() => board.label1.Text = "100"));
            board.label2.Invoke(new Action(() => board.label2.Text = "100"));
            board.label3.Invoke(new Action(() => board.label3.Text = "100"));
            board.label4.Invoke(new Action(() => board.label4.Text = "100"));

        }

    }
}

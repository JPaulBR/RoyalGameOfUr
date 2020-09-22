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
        int touchButton;

        public Form1 GameForm { get => board; set => board= value; }

        public GameController()
        {
            this.touchButton = 0;
            board = new Form1();
            logicGame = new LogicGame();
            logic_board = new Board();
            init();
        }

        public void init()
        {
            this.board.FichaA.Click += new System.EventHandler(this.FichaA_Click);
            this.board.FichaB.Click += new System.EventHandler(this.FichaB_Click);
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
            updateCount();
            MessageBox.Show("Empieza " + (logic_board.PlayerTurn == 1 ? "Amarillo" : "Rojo"));
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

        private void FichaA_Click(object sender, EventArgs e)
        {
            this.touchButton = 1;

            //Logic
            logic_board.MoveFirstToken(1, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        private void FichaB_Click(object sender, EventArgs e)
        {
            this.touchButton = 1;

            //Logic
            logic_board.MoveFirstToken(0, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonBlack0_Click(object sender, EventArgs e)
        {
            this.touchButton += 1;
            if (this.touchButton == 2)
            {
                //validation 
                this.board.button4.BackgroundImage = Properties.Resources.ficha1;
                this.board.button4.BackColor = Color.Black;
            }
            else {
                //if the button has an image token then it is 1, otherwise it is 0
                this.touchButton = 1;
                this.board.button4.BackgroundImage = null;
                this.board.button4.BackColor = Color.Red;
            }

            // b_path 0
            logic_board.MoveToken(1, 0, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();

        }

        public void buttonBlack1_Click(object sender, EventArgs e)
        {
            // b_path 1
            logic_board.MoveToken(1, 1, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonBlack2_Click(object sender, EventArgs e)
        {
            // b_path 2
            logic_board.MoveToken(1, 2, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonBlack3_Click(object sender, EventArgs e)
        {
            // b_path 3
            logic_board.MoveToken(1, 3, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonBlack4_Click(object sender, EventArgs e)
        {
            // b_path 12
            logic_board.MoveToken(1, 12, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonBlack5_Click(object sender, EventArgs e)
        {
            // b_path 13
            logic_board.MoveToken(1, 13, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonWhite0_Click(object sender, EventArgs e)
        {
            // w_path 0
            logic_board.MoveToken(0, 0, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonWhite1_Click(object sender, EventArgs e)
        {
            // w_path 1
            logic_board.MoveToken(0, 1, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonWhite2_Click(object sender, EventArgs e)
        {
            // w_path 2
            logic_board.MoveToken(0, 2, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonWhite3_Click(object sender, EventArgs e)
        {
            // w_path 3
            logic_board.MoveToken(0, 3, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonWhite4_Click(object sender, EventArgs e)
        {
            // w_path 12
            logic_board.MoveToken(0, 12, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonWhite5_Click(object sender, EventArgs e)
        {
            // w_path 13
            logic_board.MoveToken(0, 13, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter0_Click(object sender, EventArgs e)
        {
            // b_path & w_path 4
            logic_board.MoveToken(logic_board.PlayerTurn, 4, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter1_Click(object sender, EventArgs e)
        {
            // b_path & w_path 5
            logic_board.MoveToken(logic_board.PlayerTurn, 5, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter2_Click(object sender, EventArgs e)
        {
            // b_path & w_path 6
            logic_board.MoveToken(logic_board.PlayerTurn, 6, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter3_Click(object sender, EventArgs e)
        {
            // b_path & w_path 7
            logic_board.MoveToken(logic_board.PlayerTurn, 7, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter4_Click(object sender, EventArgs e)
        {
            // b_path & w_path 8
            logic_board.MoveToken(logic_board.PlayerTurn, 8, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter5_Click(object sender, EventArgs e)
        {
            // b_path & w_path 9
            logic_board.MoveToken(logic_board.PlayerTurn, 9, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter6_Click(object sender, EventArgs e)
        {
            // w_path & w_path 10
            logic_board.MoveToken(logic_board.PlayerTurn, 10, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonCenter7_Click(object sender, EventArgs e)
        {
            // w_path & w_path 11
            logic_board.MoveToken(logic_board.PlayerTurn, 11, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void updateCount()
        {
            board.label1.Invoke(new Action(() => board.label1.Text = logic_board.WhiteTotal.ToString()));
            board.label2.Invoke(new Action(() => board.label2.Text = logic_board.BlackTotal.ToString() ));
            board.label3.Invoke(new Action(() => board.label3.Text = logic_board.WhiteOut.ToString()));
            board.label4.Invoke(new Action(() => board.label4.Text = logic_board.BlackOut.ToString() ));
        }

    }
}

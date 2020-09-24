﻿using Royal.Model;
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
        int tokenInitial;
        int steps;//movements by tokens 
        Button[] listButtonHuman;
        Button[] listButtonPc;

        public Form1 GameForm { get => board; set => board = value; }

        public GameController()
        {
            this.touchButton = 0;
            board = new Form1();
            logicGame = new LogicGame();
            logic_board = new Board();
            init();
            //disableAll();
        }

        public void init()
        {
            this.board.FichaA.Click += new System.EventHandler(this.FichaA_Click);
            this.board.FichaB.Click += new System.EventHandler(this.FichaB_Click);
            this.board.H1.Click += new System.EventHandler(this.buttonBlack0_Click);
            this.board.H2.Click += new System.EventHandler(this.buttonBlack1_Click);
            this.board.H3.Click += new System.EventHandler(this.buttonBlack2_Click);
            this.board.H4.Click += new System.EventHandler(this.buttonBlack3_Click);
            this.board.H13.Click += new System.EventHandler(this.buttonBlack4_Click);
            this.board.H14.Click += new System.EventHandler(this.buttonBlack5_Click);
            this.board.P1.Click += new System.EventHandler(this.buttonWhite0_Click);
            this.board.P2.Click += new System.EventHandler(this.buttonWhite1_Click);
            this.board.P3.Click += new System.EventHandler(this.buttonWhite2_Click);
            this.board.P4.Click += new System.EventHandler(this.buttonWhite3_Click);
            this.board.P13.Click += new System.EventHandler(this.buttonWhite4_Click);
            this.board.P14.Click += new System.EventHandler(this.buttonWhite5_Click);
            this.board.N5.Click += new System.EventHandler(this.buttonCenter0_Click);
            this.board.N6.Click += new System.EventHandler(this.buttonCenter1_Click);
            this.board.N7.Click += new System.EventHandler(this.buttonCenter2_Click);
            this.board.N8.Click += new System.EventHandler(this.buttonCenter3_Click);
            this.board.N9.Click += new System.EventHandler(this.buttonCenter4_Click);
            this.board.N10.Click += new System.EventHandler(this.buttonCenter5_Click);
            this.board.N11.Click += new System.EventHandler(this.buttonCenter6_Click);
            this.board.N12.Click += new System.EventHandler(this.buttonCenter7_Click);
            this.board.throwButton.Click += new System.EventHandler(this.throwButton_Click);
            initializeButtonsHuman();
            initializeButtonsPc();
            MessageBox.Show("Empieza " + (logic_board.PlayerTurn == 1 ? "Rojo" : "Amarillo"));
            updateCount();
        }

        public void initializeButtonsHuman() {
            this.listButtonHuman = new Button[15];
            this.listButtonHuman[0] = this.board.H1;
            this.listButtonHuman[1] = this.board.H2;
            this.listButtonHuman[2] = this.board.H3;
            this.listButtonHuman[3] = this.board.H4;
            this.listButtonHuman[4] = this.board.N5;
            this.listButtonHuman[5] = this.board.N6;
            this.listButtonHuman[6] = this.board.N7;
            this.listButtonHuman[7] = this.board.N8;
            this.listButtonHuman[8] = this.board.N9;
            this.listButtonHuman[9] = this.board.N10;
            this.listButtonHuman[10] = this.board.N11;
            this.listButtonHuman[11] = this.board.N12;
            this.listButtonHuman[12] = this.board.H13;
            this.listButtonHuman[13] = this.board.H14;
            this.listButtonHuman[14] = this.board.H15;
            //changeSymbolsButton(this.listButtonHuman, false);
        }

        public void initializeButtonsPc()
        {
            this.listButtonPc = new Button[15];
            this.listButtonPc[0] = this.board.P1;
            this.listButtonPc[1] = this.board.P2;
            this.listButtonPc[2] = this.board.P3;
            this.listButtonPc[3] = this.board.P4;
            this.listButtonPc[4] = this.board.N5;
            this.listButtonPc[5] = this.board.N6;
            this.listButtonPc[6] = this.board.N7;
            this.listButtonPc[7] = this.board.N8;
            this.listButtonPc[8] = this.board.N9;
            this.listButtonPc[9] = this.board.N10;
            this.listButtonPc[10] = this.board.N11;
            this.listButtonPc[11] = this.board.N12;
            this.listButtonPc[12] = this.board.P13;
            this.listButtonPc[13] = this.board.P14;
            this.listButtonPc[14] = this.board.P15;
            //changeSymbolsButton(this.listButtonPc, true);
        }

        public void changeSymbolsButton(Button[] buttonsList, Boolean isPc) {
            for (int i = 0; i < 15; i++) {
                if (isPc) {
                    buttonsList[i].BackgroundImage = logicGame.genetareTokenPc()[i].getImage(); //obtain the image from specific i
                    buttonsList[i].BackColor = logicGame.genetareTokenPc()[i].getColor();
                }
                else {
                    buttonsList[i].BackgroundImage = logicGame.genetareTokenHuman()[i].getImage(); //obtain the image from specific i
                    buttonsList[i].BackColor = logicGame.genetareTokenHuman()[i].getColor();
                }
            }
        }

        public void disableAll()
        {
            foreach (Button b in listButtonPc)
            {
                b.Enabled = false;
            }
            foreach (Button b in listButtonHuman)
            {
                b.Enabled = false;
            }
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
            this.steps = logicGame.getStepsCount();
            MessageBox.Show("Avanza " + this.steps);
            
        }

        private void FichaA_Click(object sender, EventArgs e)
        {
            this.touchButton = 1;
            this.tokenInitial = 0;
            /*if (this.touchButton == 2)
            {
                touchButton = 0;  
                //validation 
                this.board.H1.BackgroundImage = Properties.Resources.ficha1;
                this.board.H1.BackColor = Color.Black;
            }
            else
            {
                touchButton = 1;
                //disableAll();
                List<int> tokens = logic_board.Moveable(1);
                foreach (int i in tokens)
                {
                    listButtonHuman[i].Enabled = true;
                }
                if (logic_board.MoveFirstToken(1, logicGame.getStepsCount()))
                {
                    listButtonHuman[logicGame.getStepsCount() - 1].Enabled = true;
                    listButtonHuman[logicGame.getStepsCount() - 1].BackgroundImage = null;
                    listButtonHuman[logicGame.getStepsCount() - 1].BackColor = Color.Green;
                }
            }
            //Logic
            logic_board.PrintBoard();
            updateCount();*/
        }

        private void FichaB_Click(object sender, EventArgs e)
        {
            this.touchButton = 1;
            //disableAll();
            //Logic
            logic_board.MoveFirstToken(0, logicGame.getStepsCount());
            logic_board.PrintBoard();
            updateCount();
        }

        public void buttonBlack0_Click(object sender, EventArgs e)
        {
            this.touchButton += 1;
            //if (istoken){this.touchButton = 1}
            if (this.touchButton == 2) {
                if (1+this.tokenInitial == this.steps) {
                    this.board.H1.BackgroundImage = Properties.Resources.ficha1;
                    this.board.H1.BackColor = Color.Black;
                }
            }
                /*if (this.touchButton == 2)
                {
                    //validation 
                    this.board.H1.BackgroundImage = Properties.Resources.ficha1;
                    this.board.H1.BackColor = Color.Black;
                }
                else {
                    //if the button has an image token then it is 1, otherwise it is 0
                    this.touchButton = 1;
                    this.board.H1.BackgroundImage = null;
                    this.board.H1.BackColor = Color.Red;
                }*/

                // b_path 0
            //logic_board.MoveToken(1, 0, logicGame.getStepsCount());
            //logic_board.PrintBoard();
            //updateCount();

        }

        public void buttonBlack1_Click(object sender, EventArgs e)
        {
            this.touchButton += 1;
            //if (istoken){this.touchButton = 1}
            if (this.touchButton == 2)
            {
                if (2 + this.tokenInitial == this.steps)
                {
                    this.board.H2.BackgroundImage = Properties.Resources.ficha1;
                    this.board.H2.BackColor = Color.Black;
                }
            }
            // b_path 1
            //logic_board.MoveToken(1, 1, logicGame.getStepsCount());
            //logic_board.PrintBoard();
            //updateCount();
        }

        public void buttonBlack2_Click(object sender, EventArgs e)
        {
            this.touchButton += 1;
            //if (istoken){this.touchButton = 1}
            if (this.touchButton == 2)
            {
                if (3 + this.tokenInitial == this.steps)
                {
                    this.board.H3.BackgroundImage = Properties.Resources.ficha1;
                    this.board.H3.BackColor = Color.Black;
                }
            }
            // b_path 2
            //logic_board.MoveToken(1, 2, logicGame.getStepsCount());
            //logic_board.PrintBoard();
            //updateCount();
        }

        public void buttonBlack3_Click(object sender, EventArgs e)
        {
            this.touchButton += 1;
            //if (istoken){this.touchButton = 1}
            if (this.touchButton == 2)
            {
                if (4 + this.tokenInitial == this.steps)
                {
                    this.board.H4.BackgroundImage = Properties.Resources.ficha1;
                    this.board.H4.BackColor = Color.Black;
                }
            }
            // b_path 3
            //logic_board.MoveToken(1, 3, logicGame.getStepsCount());
            //logic_board.PrintBoard();
            //updateCount();
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
            updateTurn();
        }

        public void updateTurn()
        {
            board.labelTurno.Invoke(new Action(() => board.labelTurno.Text = logic_board.PlayerTurn == 1 ? "Rojo" : "Amarillo"));
        }

    }
}

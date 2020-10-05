using Royal.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Royal.Machine;

namespace Royal.Controller
{
    class GameController
    {
        private Board logic_board;
        private Form1 board;
        private LogicGame logicGame;
        Machine pc = new Machine();
        int touchButton;
        int tokenInitial;
        int steps;//movements by tokens 
        Button[] listButtonHuman;
        Button[] listButtonPc;

        public Form1 GameForm { get => board; set => board = value; }

        public GameController()
        {
            logic_board = new Board();

            int[] list = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //pc.WriteInJson(1, list, list, 1, 1); //is for write to the json file
            int[][] l = { logic_board.WhitePath, logic_board.BlackPath };
            //pc.MakeTree(l, logic_board.PlayerTurn);

            this.touchButton = 0;
            board = new Form1();
            logicGame = new LogicGame();
            init();
            if (logic_board.PlayerTurn == 0)
            {
                throwDice();
                nextPCTurn();
            }
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
            this.board.P15.Click += new System.EventHandler(this.buttonWhite6_Click);
            this.board.H15.Click += new System.EventHandler(this.buttonBlack6_Click);
            this.board.throwButton.Click += new System.EventHandler(this.throwButton_Click);
            initializeButtonsHuman();
            initializeButtonsPc();
            MessageBox.Show("Empieza " + (logic_board.PlayerTurn == 1 ? "Amarillo" : "Rojo"));
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
        }

        public void refreshButtons() {
            List<int> player1 = logic_board.Moveable(0); // Rojas
            List<int> player2 = logic_board.Moveable(1); // Amarillas
            for (int i = 0; i < 15; i++)
            {
                if (!player1.Contains(i) && !player2.Contains(i))
                {
                    listButtonPc[i].BackgroundImage = logicGame.genetareTokenPc()[i].getImage(); //obtain the image from specific i
                    listButtonPc[i].BackColor = logicGame.genetareTokenPc()[i].getColor();
                }
                if (!player2.Contains(i) && !player1.Contains(i))
                {
                    listButtonHuman[i].BackgroundImage = logicGame.genetareTokenPc()[i].getImage(); //obtain the image from specific i
                    listButtonHuman[i].BackColor = logicGame.genetareTokenPc()[i].getColor();
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
            throwDice();
        }

        public void throwDice()
        {
            Image[] resultList;
            int i = 0;
            while (i < 1)
            {
                resultList = logicGame.throwChips();
                this.board.chip1.BackgroundImage = resultList[0];
                this.board.chip2.BackgroundImage = resultList[1];
                this.board.chip3.BackgroundImage = resultList[2];
                Thread.Sleep(500);
                i++;
            }
            this.steps = logicGame.getStepsCount();
            if (this.steps == 0) {
                this.steps = 3;
            }
            MessageBox.Show("Avanza " + this.steps);
        }

        private bool isTokenPosition(int index, List<int> tokens)
        {
            foreach (int element in tokens)
            {
                if (index == element)
                {
                    return true;
                }
            }
            return false;
        }

        //1 is for human, 0 is for pc
        public bool changeSymbolButton(Button btn, int index, int player)
        {
            List<int> tokens = logic_board.Moveable(player);
            if (isTokenPosition(index, tokens))
            {
                this.touchButton = 1;
                this.tokenInitial = index;
            }
            else
            {
                this.touchButton += 1;
                if (this.touchButton == 2)
                {
                    if (index == this.tokenInitial + this.steps)
                    {
                        btn.BackgroundImage = Properties.Resources.ficha1;
                        btn.BackColor = Color.Black;
                        bool movements;
                        if (this.tokenInitial == -1)
                        {
                            movements = logic_board.MoveFirstToken(player, this.steps);
                        }
                        else
                        {
                            movements = logic_board.MoveToken(player, index - this.steps, this.steps);
                        }
                        if (logic_board.CheckWin(player))
                        {
                            return true;
                        }
                        logic_board.ChangeTurn();
                        logic_board.PrintBoard();
                        updateCount();
                        refreshButtons();
                        //
                        if (logic_board.PlayerTurn == 0)
                        {
                            throwDice();
                            nextPCTurn();
                        }
                    }
                }
            }
            return false;
        }

        private int nextPCTurn()
        {
            logic_board.ChangeTurn();
            updateCount();
            refreshButtons();
            return 0;
        }

        private void FichaA_Click(object sender, EventArgs e)
        {
            this.touchButton = 1;
            this.tokenInitial = -1;
            List<int> tokens = logic_board.Moveable(1);
            foreach (int i in tokens)
            {
                listButtonHuman[i].Enabled = true;

            }
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
            changeSymbolButton(this.board.H1, 0, 1);
        }


        public void buttonBlack1_Click(object sender, EventArgs e)
        {
            // b_path 1
            changeSymbolButton(this.board.H2, 1, 1);
        }

        public void buttonBlack2_Click(object sender, EventArgs e)
        {
            // b_path 2
            changeSymbolButton(this.board.H3, 2, 1);
        }

        public void buttonBlack3_Click(object sender, EventArgs e)
        {
            // b_path 3
            changeSymbolButton(this.board.H4, 3, 1);
        }

        public void buttonBlack4_Click(object sender, EventArgs e)
        {
            // b_path 12
            changeSymbolButton(this.board.H13, 12, 1);
        }

        public void buttonBlack5_Click(object sender, EventArgs e)
        {
            // b_path 13
            changeSymbolButton(this.board.H14, 13, 1);
        }

        public void buttonWhite0_Click(object sender, EventArgs e)
        {
            // w_path 0
            changeSymbolButton(this.board.P1, 0, 0);
        }

        public void buttonWhite1_Click(object sender, EventArgs e)
        {
            // w_path 1
            changeSymbolButton(this.board.P2, 1, 0);
        }

        public void buttonWhite2_Click(object sender, EventArgs e)
        {
            // w_path 2
            changeSymbolButton(this.board.P3, 2, 0);
        }

        public void buttonWhite3_Click(object sender, EventArgs e)
        {
            // w_path 3
            changeSymbolButton(this.board.P4, 3, 0);
        }

        public void buttonWhite4_Click(object sender, EventArgs e)
        {
            // w_path 12
            changeSymbolButton(this.board.P13, 12, 0);
        }

        public void buttonWhite5_Click(object sender, EventArgs e)
        {
            // w_path 13
            changeSymbolButton(this.board.P14, 13, 0);
        }

        public void buttonCenter0_Click(object sender, EventArgs e)
        {
            // b_path & w_path 4
            changeSymbolButton(this.board.N5, 4, logic_board.PlayerTurn);
        }

        public void buttonCenter1_Click(object sender, EventArgs e)
        {
            // b_path & w_path 5
            changeSymbolButton(this.board.N6, 5, logic_board.PlayerTurn);
        }

        public void buttonCenter2_Click(object sender, EventArgs e)
        {
            // b_path & w_path 6
            changeSymbolButton(this.board.N7, 6, logic_board.PlayerTurn);
        }

        public void buttonCenter3_Click(object sender, EventArgs e)
        {
            // b_path & w_path 7
            changeSymbolButton(this.board.N8, 7, logic_board.PlayerTurn);
        }

        public void buttonCenter4_Click(object sender, EventArgs e)
        {
            // b_path & w_path 8
            changeSymbolButton(this.board.N9, 8, logic_board.PlayerTurn);
        }

        public void buttonCenter5_Click(object sender, EventArgs e)
        {
            // b_path & w_path 9
            changeSymbolButton(this.board.N10, 9, logic_board.PlayerTurn);
        }

        public void buttonCenter6_Click(object sender, EventArgs e)
        {
            // w_path & w_path 10
            changeSymbolButton(this.board.N11, 10, logic_board.PlayerTurn);
        }

        public void buttonCenter7_Click(object sender, EventArgs e)
        {
            // w_path & w_path 11
            changeSymbolButton(this.board.N12, 11, logic_board.PlayerTurn);
        }

        public void buttonWhite6_Click(object sender, EventArgs e)
        {
            // w_path 14
            changeSymbolButton(this.board.P15, 14, logic_board.PlayerTurn);
        }

        public void buttonBlack6_Click(object sender, EventArgs e)
        {
            // w_path 14
            changeSymbolButton(this.board.H15, 14, logic_board.PlayerTurn);
        }

        public void updateCount()
        {
            board.label1.Invoke(new Action(() => board.label1.Text = logic_board.BlackTotal.ToString()));
            board.label2.Invoke(new Action(() => board.label2.Text = logic_board.WhiteTotal.ToString()));
            board.H15.Invoke(new Action(() => board.H15.Text = logic_board.BlackOut.ToString()));
            board.P15.Invoke(new Action(() => board.P15.Text = logic_board.WhiteOut.ToString() ));
            updateTurn();
        }

        public void updateTurn()
        {
            board.labelTurno.Invoke(new Action(() => board.labelTurno.Text = logic_board.PlayerTurn == 1 ? "Amarillo" : "Rojo"));
        }

    }
}

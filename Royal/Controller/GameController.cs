using Royal.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royal.Controller
{
    class GameController
    {
        private Board logic_board;
        private Form1 board;

        public Form1 GameForm { get => board; set => board= value; }

        public GameController()
        {
            logic_board = new Board();
            board = new Form1();
        }
    }
}

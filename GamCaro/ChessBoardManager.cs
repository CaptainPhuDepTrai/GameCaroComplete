﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamCaro
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;

        public Panel ChessBoard { get => chessBoard; set => chessBoard = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
       
       

        private List<Player> Player;

        private int currentPlayer;

        private TextBox playerName;
        public TextBox PlayerName { get => playerName; set => playerName = value; }


        private PictureBox playerMark;
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }

        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            this.Player = new List<Player>()
            {
                new Player("boy" , Image.FromFile(Application.StartupPath + "\\Resources\\boy.jpg")),
                new Player("girl", Image.FromFile(Application.StartupPath + "\\Resources\\girl.jpg"))
            };

            CurrentPlayer = 0;

            ChangePlayer(); 
        }

        
        #endregion

        #region Method
        public void DrawChessBoard()
        {
            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Constan.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Constan.CHESS_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Constan.CHESS_WIDTH,
                        Height = Constan.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                        
                    };
                    btn.Click += btn_Click;

                    ChessBoard.Controls.Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Constan.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;

            }


        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
            {
                return;
            }

            Mark(btn);
            ChangePlayer();
            
            
        }

        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;

        }

        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }
        #endregion

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessMVC
{
    public partial class MainForm : Form, IBoardView
    {
        public static readonly int CELL_SIZE = 42;
        public static readonly int BOARD_SIZE = 8 * CELL_SIZE;

        private ChessBoard board;
        private HotSeatController controller;

        public event FigureSelected OnFigureSelected;
        public event FigureMove OnFigureMove;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StartNewGame();
        }

        private void StartNewGame()
        {
            if (this.board != null)
            {
                this.OnFigureSelected -= this.controller.Select;
                this.OnFigureMove -= this.controller.MoveTo;
            }
            this.board = new ChessBoard();
            this.board.ChessBoardChanged += this.Refresh;
            this.controller = new HotSeatController(this.board);
            this.OnFigureSelected += this.controller.Select;
            this.OnFigureMove += this.controller.MoveTo;
            this.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.StartNewGame();
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChessBoardPaint);
        }

        private void ChessBoardPaint(object sender, PaintEventArgs e)
        {
            for (int x = 0; x < ChessBoard.SIZE; x++)
            {
                for (int y = 0; y < ChessBoard.SIZE; y++)
                {
                    System.Drawing.Color cellColor = (x + y) % 2 == 0 ? System.Drawing.Color.Gray : System.Drawing.Color.DarkGray;
                    if (this.board.SelectedFigure != null)
                    {
                        Figure selectedFigure = this.board.SelectedFigure;
                        if (selectedFigure.GetAvailableMoves(this.board).Contains(new Square(x, y)))
                        {
                            cellColor = (x + y) % 2 == 0 ? System.Drawing.Color.Khaki : System.Drawing.Color.DarkKhaki;
                        }
                    }
                    SolidBrush myBrush = new SolidBrush(cellColor);
                    e.Graphics.FillRectangle(myBrush, new Rectangle(x * CELL_SIZE, BOARD_SIZE - y * CELL_SIZE, CELL_SIZE, CELL_SIZE));
                    Figure figure = board.Figures[x, y];
                    if (figure != null)
                    {
                        e.Graphics.DrawImage(figure.GetImage(), x * CELL_SIZE, BOARD_SIZE - y * CELL_SIZE);
                    }
                }
            }
            int whitePoints = 0;
            int blackPoints = 0;
            for (int i = 0; i < this.board.CapturedFigures.Count; i++)
            {
                Figure figure = this.board.CapturedFigures[i];
                if (figure.Color == Color.BLACK)
                {
                    whitePoints += figure.Points;
                }
                if (figure.Color == Color.WHITE)
                {
                    blackPoints += figure.Points;
                }
                e.Graphics.DrawImage(figure.GetImage(), i * CELL_SIZE, BOARD_SIZE + 2 * CELL_SIZE);
            }
            this.scoreLabel.Text = whitePoints + " - " + blackPoints;
            if (this.board.Winner != null)
            {
                MessageBox.Show(this.board.Winner + " wins", "Info", MessageBoxButtons.OK);
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / CELL_SIZE;
            int y = 8 - (e.Y / CELL_SIZE);
            if (this.board.SelectedFigure == null)
            {
                try
                {
                    if (this.board.Figures[x, y] != null)
                    {
                        this.OnFigureSelected(this.board.Figures[x, y]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                try
                {
                    this.OnFigureMove(new Square(x, y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
                
            }
        }

        private void showTurnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TurnsHistoryForm turnsHistoryForm = new TurnsHistoryForm(this.board);
            turnsHistoryForm.Show();
        }
    }
}

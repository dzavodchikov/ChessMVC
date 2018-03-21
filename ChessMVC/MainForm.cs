using System;
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
            this.board = new ChessBoard();
            this.board.OnChanged += this.Refresh;
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

                    SolidBrush myBrush = new SolidBrush((x + y) % 2 == 0 ? System.Drawing.Color.Gray : System.Drawing.Color.DarkGray);
                    e.Graphics.FillRectangle(myBrush, new Rectangle(x * CELL_SIZE, BOARD_SIZE - y * CELL_SIZE, CELL_SIZE, CELL_SIZE));
                    Figure figure = board.Figures[x, y];
                    if (figure != null)
                    {
                        e.Graphics.DrawImage(figure.GetImage(), x * CELL_SIZE, BOARD_SIZE - y * CELL_SIZE);
                    }
                }
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
                        this.OnFigureSelected(new Cell(x, y));
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
                    this.OnFigureMove(this.board.SelectedFigure, new Cell(x, y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
                
            }
        }
    }
}

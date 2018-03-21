using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class ChessBoard
    {
        public static readonly int SIZE = 8;

        public ChessBoard()
        {
            this.Figures = new Figure[SIZE, SIZE];
            this.SelectedFigure = null;
            this.EatenFigures = new List<Figure>();
            for (int x = 0; x < SIZE; x++)
            {
                this.Figures[x, 1] = new Pawn(Color.WHITE);
                this.Figures[x, 6] = new Pawn(Color.BLACK);
            }
            this.Figures[0, 0] = new Rook(Color.WHITE);
            this.Figures[7, 0] = new Rook(Color.WHITE);
            this.Figures[0, 7] = new Rook(Color.BLACK);
            this.Figures[7, 7] = new Rook(Color.BLACK);
            this.Figures[1, 0] = new Knight(Color.WHITE);
            this.Figures[6, 0] = new Knight(Color.WHITE);
            this.Figures[1, 7] = new Knight(Color.BLACK);
            this.Figures[6, 7] = new Knight(Color.BLACK);
            this.Figures[2, 0] = new Bishop(Color.WHITE);
            this.Figures[5, 0] = new Bishop(Color.WHITE);
            this.Figures[2, 7] = new Bishop(Color.BLACK);
            this.Figures[5, 7] = new Bishop(Color.BLACK);
            this.Figures[3, 0] = new Queen(Color.WHITE);
            this.Figures[4, 0] = new King(Color.WHITE);
            this.Figures[3, 7] = new Queen(Color.BLACK);
            this.Figures[4, 7] = new King(Color.BLACK);
        }

        public Figure[,] Figures { get; set; }
        public Cell SelectedFigure { get; set; }
        public List<Figure> EatenFigures { get; set; } 
        public event ChessBoardChanged OnChanged;

        public void FireUpdate()
        {
            this.OnChanged();
        }

    }

    public delegate void ChessBoardChanged();

}

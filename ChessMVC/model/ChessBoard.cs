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

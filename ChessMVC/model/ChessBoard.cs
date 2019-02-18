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

        public Color NextTurn { get; set; }
        public Figure[,] Figures { get; set; }
        public Figure SelectedFigure { get; set; }
        public IList<Figure> CapturedFigures { get; set; }
        public IList<String> Turns { get; set; } 

        public event ChessBoardChanged OnChanged;

        public ChessBoard()
        {
            this.NextTurn = Color.WHITE;
            this.Figures = new Figure[SIZE, SIZE];
            this.SelectedFigure = null;
            this.CapturedFigures = new List<Figure>();
            this.Turns = new List<String>();
            for (int x = 0; x < SIZE; x++)
            {
                this.PutFigureOnSquare(new Square(x, 1), new Pawn(Color.WHITE));
                this.PutFigureOnSquare(new Square(x, 6), new Pawn(Color.BLACK));
            }
            this.PutFigureOnSquare(new Square(0, 0), new Rook(Color.WHITE));
            this.PutFigureOnSquare(new Square(7, 0), new Rook(Color.WHITE));
            this.PutFigureOnSquare(new Square(0, 7), new Rook(Color.BLACK));
            this.PutFigureOnSquare(new Square(7, 7), new Rook(Color.BLACK));
            this.PutFigureOnSquare(new Square(1, 0), new Knight(Color.WHITE));
            this.PutFigureOnSquare(new Square(6, 0), new Knight(Color.WHITE));
            this.PutFigureOnSquare(new Square(1, 7), new Knight(Color.BLACK));
            this.PutFigureOnSquare(new Square(6, 7), new Knight(Color.BLACK));
            this.PutFigureOnSquare(new Square(2, 0), new Bishop(Color.WHITE));
            this.PutFigureOnSquare(new Square(5, 0), new Bishop(Color.WHITE));
            this.PutFigureOnSquare(new Square(2, 7), new Bishop(Color.BLACK));
            this.PutFigureOnSquare(new Square(5, 7), new Bishop(Color.BLACK));
            this.PutFigureOnSquare(new Square(3, 0), new Queen(Color.WHITE));
            this.PutFigureOnSquare(new Square(4, 0), new King(Color.WHITE));
            this.PutFigureOnSquare(new Square(3, 7), new Queen(Color.BLACK));
            this.PutFigureOnSquare(new Square(4, 7), new King(Color.BLACK));
        }

        public void PutFigureOnSquare(Square square, Figure figure)
        {
            figure.Square = square;
            this.Figures[square.X, square.Y] = figure;
        }

        public void ClearSquare(Square square)
        {
            this.Figures[square.X, square.Y] = null;
        }

        public void CaptureFigure(Figure figure)
        {
            this.CapturedFigures.Add(figure);
        }

        public void FireUpdate()
        {
            this.OnChanged();
        }

        public bool IsEmptyOrEnemyFigure(int x, int y, Color color)
        {
            return this.Figures[x, y] == null || this.Figures[x, y].Color != color;
        }

    }

    public delegate void ChessBoardChanged();

}

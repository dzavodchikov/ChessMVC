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
        public Cell SelectedFigure { get; set; }
        public List<Figure> EatenFigures { get; set; }

        public event ChessBoardChanged OnChanged;

        public ChessBoard()
        {
            this.Figures = new Figure[SIZE, SIZE];
            this.SelectedFigure = null;
            this.EatenFigures = new List<Figure>();
            this.NextTurn = Color.WHITE;
            for (int x = 0; x < SIZE; x++)
            {
                this.PutFigureOnField(new Cell(x, 1), new Pawn(Color.WHITE, this));
                this.PutFigureOnField(new Cell(x, 6), new Pawn(Color.BLACK, this));
            }
            this.PutFigureOnField(new Cell(0, 0), new Rook(Color.WHITE, this));
            this.PutFigureOnField(new Cell(7, 0), new Rook(Color.WHITE, this));
            this.PutFigureOnField(new Cell(0, 7), new Rook(Color.BLACK, this));
            this.PutFigureOnField(new Cell(7, 7), new Rook(Color.BLACK, this));
            this.PutFigureOnField(new Cell(1, 0), new Knight(Color.WHITE, this));
            this.PutFigureOnField(new Cell(6, 0), new Knight(Color.WHITE, this));
            this.PutFigureOnField(new Cell(1, 7), new Knight(Color.BLACK, this));
            this.PutFigureOnField(new Cell(6, 7), new Knight(Color.BLACK, this));
            this.PutFigureOnField(new Cell(2, 0), new Bishop(Color.WHITE, this));
            this.PutFigureOnField(new Cell(5, 0), new Bishop(Color.WHITE, this));
            this.PutFigureOnField(new Cell(2, 7), new Bishop(Color.BLACK, this));
            this.PutFigureOnField(new Cell(5, 7), new Bishop(Color.BLACK, this));
            this.PutFigureOnField(new Cell(3, 0), new Queen(Color.WHITE, this));
            this.PutFigureOnField(new Cell(4, 0), new King(Color.WHITE, this));
            this.PutFigureOnField(new Cell(3, 7), new Queen(Color.BLACK, this));
            this.PutFigureOnField(new Cell(4, 7), new King(Color.BLACK, this));
        }

        public void PutFigureOnField(Cell cell, Figure figure)
        {
            figure.Cell = cell;
            this.Figures[cell.X, cell.Y] = figure;
        }

        public void ClearField(Cell cell)
        {
            this.Figures[cell.X, cell.Y] = null;
        }

        public void EatFigure(Figure figure)
        {
            this.EatenFigures.Add(figure);
        }

        public void FireUpdate()
        {
            this.OnChanged();
        }

    }

    public delegate void ChessBoardChanged();

}

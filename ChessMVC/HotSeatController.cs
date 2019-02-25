using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class HotSeatController : IChessController
    {
        private ChessBoard board;

        public HotSeatController(ChessBoard board)
        {
            this.board = board;
        }

        public void MoveTo(Square to)
        {
            if (this.board.Winner != null)
            {
                throw new Exception("Game finished");
            }
            Color currentTurn = this.board.NextTurn;
            Figure figure = this.board.SelectedFigure;
            if (figure == null)
            {
                throw new Exception();
            }
            if (figure.GetAvailableMoves(this.board).Contains(to) == false)
            {
                throw new Exception("Can't move to this cell");
            }
            Square from = figure.Square;
            Figure other = this.board.Figures[to.X, to.Y];
            if (other != null)
            {
                if (figure.Color != other.Color)
                {
                    this.board.CaptureFigure(other);
                }
                else
                {
                    throw new Exception("Can't capture own figure");
                }
            }
            this.board.ClearSquare(figure.Square);
            this.board.PutFigureOnSquare(new Square(to.X, to.Y), figure);
            this.board.SelectedFigure = null;
            this.board.Turns.Add(this.CreateTurn(figure, from, to));
            this.board.NextTurn = currentTurn == Color.WHITE ? Color.BLACK : Color.WHITE;
            this.checkEndOfGame(currentTurn);
            this.board.OnChessBoardChanged();
        }

        private void checkEndOfGame(Color color)
        {
            Figure king = this.getKing(color);
            foreach (Figure figure in board.Figures)
            {
                if (figure != null && figure.Color != color && figure.GetAvailableMoves(this.board).Contains(king.Square))
                {
                    this.board.Winner = color == Color.WHITE ? Color.BLACK : Color.WHITE;
                }
            }
        }

        private Figure getKing(Color color)
        {
            foreach (Figure figure in board.Figures)
            {
                if (figure != null && figure is King && figure.Color == color)
                {
                    return figure;
                }
            }
            throw new Exception();
        }

        public void Select(Figure figure)
        {
            if (this.board.Winner != null)
            {
                throw new Exception("Game finished");
            }
            if (figure == null)
            {
                throw new Exception("Please select " + this.board.NextTurn + " figure");
            }
            if (figure.Color != this.board.NextTurn)
            {
                throw new Exception("Please select " + this.board.NextTurn + " figure");
            }
            if (figure.GetAvailableMoves(this.board).Count == 0)
            {
                throw new Exception("Please select another " + this.board.NextTurn + " figure");
            }
            this.board.SelectedFigure = figure;
            this.board.OnChessBoardChanged();
        }

        private string CreateTurn(Figure figure, Square from, Square to)
        {
            return figure.Color + " " + figure.GetType().Name + " " + GetFieldAlpha(from.X) + GetFieldNum(from.Y) + " -> " + GetFieldAlpha(to.X) + GetFieldNum(to.Y);
        }

        private char GetFieldAlpha(int x)
        {
            byte b = (byte)(65 + x);
            return (char)b;
        }

        private int GetFieldNum(int x)
        {
            return x + 1;
        }

    }
}

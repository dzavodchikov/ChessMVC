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
            Figure figure = this.board.SelectedFigure;
            if (figure == null)
            {
                throw new Exception();
            }
            if (figure.GetAvailableMoves().Contains(to) == false)
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
            this.board.NextTurn = this.board.NextTurn == Color.WHITE ? Color.BLACK : Color.WHITE;
            this.board.FireUpdate();
        }

        public void Select(Figure figure)
        {
            if (figure == null)
            {
                throw new Exception("Please select " + this.board.NextTurn + " figure");
            }
            if (figure.Color != this.board.NextTurn)
            {
                throw new Exception("Please select " + this.board.NextTurn + " figure");
            }
            this.board.SelectedFigure = figure;
            this.board.FireUpdate();
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

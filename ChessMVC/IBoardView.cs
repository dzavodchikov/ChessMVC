using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public interface IBoardView
    {
        event FigureSelected OnFigureSelected;
        event FigureMove OnFigureMove;
    }

    public delegate void FigureMove(Square to);
    public delegate void FigureSelected(Figure figure);
}

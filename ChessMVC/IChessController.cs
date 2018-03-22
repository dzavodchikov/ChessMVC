using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public interface IChessController
    {
        void Select(Figure figure);
        void MoveTo(Square to);
    }
}

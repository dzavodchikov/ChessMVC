using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public interface IChessController
    {
        void Select(Cell cell);
        void MoveTo(Cell from, Cell to);
    }
}

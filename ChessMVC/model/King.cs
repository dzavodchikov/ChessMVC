﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMVC
{
    public class King : Figure
    {
        public King(Color color)
        {
            this.Points = 100;
            this.Color = color;
        }

        public override IList<Square> GetAvailableMoves(ChessBoard board)
        {
            List<Square> availableMoves = new List<Square>();
            return availableMoves;
        }

        public override Bitmap GetImage()
        {
            if (this.Color == Color.WHITE)
            {
                return Resources.white_king;
            }
            else
            {
                return Resources.black_king;
            }
        }
    }
}

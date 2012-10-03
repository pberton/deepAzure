using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class PieceKing : PieceBase
    {
        public override void CalculateValidMoves()
        {

        }

        public PieceKing(PieceColor color)
        {
            // TODO: Complete member initialization
            this.Color = color;
        }
    }
}
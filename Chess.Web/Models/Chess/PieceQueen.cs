using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class PieceQueen : PieceBase
    {
        public override void CalculateValidMoves()
        {

        }

        public PieceQueen(PieceColor color)
        {
            // TODO: Complete member initialization
            this.Color = color;
        }
    }
}
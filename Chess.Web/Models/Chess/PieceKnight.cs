using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class PieceKnight : PieceBase
    {

        public PieceKnight(PieceColor color)
        {
            this.Color = color;
        }

        public override void CalculateValidMoves()
        {

        }
    }
}
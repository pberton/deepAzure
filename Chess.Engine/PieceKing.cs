using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public class PieceKing : PieceBase
    {
        public PieceKing(PieceColor color)
        {
            this.Color = color;
        }

        public override void CalculateValidMoves()
        {
            this.ValidMoves.Clear();

            var ySubstract1 = (char)(this.Square.Y - 1);
            var xSubstract1 = (char)(this.Square.X - 1);
            var yAdd1 = (char)(this.Square.Y + 1);
            var xAdd1 = (char)(this.Square.X + 1);

            ReadSquareMove(this.Square.X, ySubstract1);
            ReadSquareMove(this.Square.X, yAdd1);

            ReadSquareMove(xSubstract1, this.Square.Y);
            ReadSquareMove(xAdd1, this.Square.Y);

            ReadSquareMove(xSubstract1, ySubstract1);
            ReadSquareMove(xAdd1, ySubstract1);

            ReadSquareMove(xSubstract1, yAdd1);
            ReadSquareMove(xAdd1, yAdd1);
        }
    }
}
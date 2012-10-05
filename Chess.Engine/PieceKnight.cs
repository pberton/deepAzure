using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public class PieceKnight : PieceBase
    {

        public PieceKnight(PieceColor color)
        {
            this.Color = color;
        }

        public override void CalculateValidMoves()
        {
            this.ValidMoves.Clear();

            var ySubstract1 = (char)(this.Square.Y - 1);
            var ySubstract2 = (char)(this.Square.Y - 2);
            var xSubstract1 = (char)(this.Square.X - 1);
            var xSubstract2 = (char)(this.Square.X - 2);
            var yAdd1 = (char)(this.Square.Y + 1);
            var yAdd2 = (char)(this.Square.Y + 2);
            var xAdd1 = (char)(this.Square.X + 1);
            var xAdd2 = (char)(this.Square.X + 2);

            ReadSquareMove(xAdd1, ySubstract2);
            ReadSquareMove(xSubstract1, ySubstract2);

            ReadSquareMove(xAdd1, yAdd2);
            ReadSquareMove(xSubstract1, yAdd2);

            ReadSquareMove(xSubstract2, ySubstract1);
            ReadSquareMove(xSubstract2, yAdd1);

            ReadSquareMove(xAdd2, ySubstract1);
            ReadSquareMove(xAdd2, yAdd1);
        }
    }
}
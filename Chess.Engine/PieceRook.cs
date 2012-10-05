using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public class PieceRook: PieceBase
    {
        public PieceRook(PieceColor color)
        {
            this.Color = color;
        }

        public override void CalculateValidMoves()
        {
            this.ValidMoves.Clear();

            for (char y = (char)(this.Square.Y + 1); y <= '8'; y++)
            {
                if (!ReadSquareMove(this.Square.X,y))
                    break;
            }

            for (char y = (char)(this.Square.Y - 1); y >= '1'; y--)
            {
                if (!ReadSquareMove(this.Square.X, y))
                    break;
            }

            for (char x =  (char)(this.Square.X + 1); x <= 'h'; x++)
            {
                if (!ReadSquareMove(x, this.Square.Y))
                    break;
            }

            for (char x = (char)( this.Square.X - 1); x >= 'a'; x--)
            {
                if (!ReadSquareMove(x, this.Square.Y))
                    break;
            }
        }

    }
}
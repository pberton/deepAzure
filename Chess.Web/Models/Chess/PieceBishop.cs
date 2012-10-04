using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class PieceBishop : PieceBase
    {
        public PieceBishop(PieceColor color)
        {
            this.Color = color;
        }

        public override void CalculateValidMoves()
        {
            this.ValidMoves.Clear();

            for (int i = 1; i < 8; i++)
            {
                char x = (char)(this.Square.X + i);
                char y = (char)(this.Square.Y + i);
                if (!ReadSquareMove(x, y))
                    break;
            }

            for (int i = 1; i < 8; i++)
            {
                char x = (char)(this.Square.X + i);
                char y = (char)(this.Square.Y - i);
                if (!ReadSquareMove(x, y))
                    break;
            }

            for (int i = 1; i < 8; i++)
            {
                char x = (char)(this.Square.X - i);
                char y = (char)(this.Square.Y - i);
                if (!ReadSquareMove(x, y))
                    break;
            }

            for (int i = 1; i < 8; i++)
            {
                char x = (char)(this.Square.X - i);
                char y = (char)(this.Square.Y + i);
                if (!ReadSquareMove(x, y))
                    break;
            }
        }
    }
}
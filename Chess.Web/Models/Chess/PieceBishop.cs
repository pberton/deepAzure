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
                if (!ReadNextSquare(x, y))
                    break;
            }

            for (int i = 1; i < 8; i++)
            {
                char x = (char)(this.Square.X + i);
                char y = (char)(this.Square.Y - i);
                if (!ReadNextSquare(x, y))
                    break;
            }

            for (int i = 1; i < 8; i++)
            {
                char x = (char)(this.Square.X - i);
                char y = (char)(this.Square.Y - i);
                if (!ReadNextSquare(x, y))
                    break;
            }

            for (int i = 1; i < 8; i++)
            {
                char x = (char)(this.Square.X - i);
                char y = (char)(this.Square.Y + i);
                if (!ReadNextSquare(x, y))
                    break;
            }
        }


        private bool ReadNextSquare(char x, char y)
        {
            if (this.Board.IsEmptySquare(x, y))
            {
                this.AddValidMove(x, y);
                return true;
            }
            else
            {
                if (this.Board.IsOccupiedSquare(x, y, this.Color.Opposite()))
                    this.AddValidMove(x, y);
                return false;
            }

        }

    }
}
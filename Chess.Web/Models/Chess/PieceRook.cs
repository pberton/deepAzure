using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
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
                if (!ReadNextSquare(this.Square.X,y))
                    break;
            }

            for (char y = (char)(this.Square.Y - 1); y >= '1'; y--)
            {
                if (!ReadNextSquare(this.Square.X, y))
                    break;
            }

            for (char x =  (char)(this.Square.X + 1); x <= 'h'; x++)
            {
                if (!ReadNextSquare(x, this.Square.Y))
                    break;
            }

            for (char x = (char)( this.Square.X - 1); x >= 'a'; x--)
            {
                if (!ReadNextSquare(x, this.Square.Y))
                    break;
            }
        }

        private bool ReadNextSquare(char x, char y)
        {
            if (this.Board.IsEmptySquare(x,y))
            {
                this.AddValidMove(x,y);
                return true;
            }
            else 
            {
                if (this.Board.IsOccupiedSquare(x, y, this.Color.Opposite()))
                    this.AddValidMove(x,y);
                return false;
            }
        }
    }
}
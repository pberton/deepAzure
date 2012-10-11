using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public class BoardSquare
    {
        public char X { get; private set; }
        public char Y { get; private set; }
        public PieceBase Piece { get; set; }
        public Board Board { get; private set; }

        public BoardSquare(Board board, char x, char y)
        {
            this.X = x;
            this.Y = y;
            this.Board = board;
        }

        public override bool Equals(object obj)
        {
            if (obj is BoardSquare)
                return this.GetHashCode().Equals(((BoardSquare)obj).GetHashCode());
            return false;
        }

        public override int GetHashCode()
        {
            return BoardSquare.GetHashCode(this.X,this.Y);
        }

        public static int GetHashCode(char x, char y)
        {
            return x * 100 + y;
        }

        public override string ToString()
        {
            return string.Concat(this.X, this.Y);
        }
    }
}
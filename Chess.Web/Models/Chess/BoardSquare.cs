using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class BoardSquare
    {
        public int Index { get; private set; }
        public PieceBase Piece { get; set; }
        public Board Board { get; private set; }

        public BoardSquare(Board board, int index)
        {
            this.Index = index;
            this.Board = board;
        }

        public override bool Equals(object obj)
        {
            if (obj is BoardSquare)
                return this.Index.Equals(((BoardSquare)obj).Index);
            return false;
        }

        public override int GetHashCode()
        {
            return this.Index.GetHashCode();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class PiecePawn : PieceBase
    {
        public override void CalculateValidMoves()
        {
            int nextSquareIndex = 0;
            if (this.Color ==  PieceColor.White)
               nextSquareIndex = this.Square.Index - 8;
            else
               nextSquareIndex = this.Square.Index + 8;

            if (this.Board[nextSquareIndex].Piece == null)
                this.ValidMoves.Add(nextSquareIndex);
        }
    }
}
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
            this.ValidMoves.Clear();

            int nextSquareIndex = -1;
            int index =  this.Square.Index;

            if (this.Color == PieceColor.White)
            {
                nextSquareIndex = index - 8;
                if (nextSquareIndex > -1 && this.Board[nextSquareIndex].Piece == null)
                    this.ValidMoves.Add(this.Board[nextSquareIndex]);
                if (index > 47 && index < 56)
                {
                    nextSquareIndex -= 8;
                    if (this.Board[nextSquareIndex].Piece == null)
                        this.ValidMoves.Add(this.Board[nextSquareIndex]);
                }
            }
            else
            {
                nextSquareIndex = index + 8;
                if (nextSquareIndex < 64 && this.Board[nextSquareIndex].Piece == null)
                    this.ValidMoves.Add(this.Board[nextSquareIndex]);
                if (index > 7 && index < 16)
                {
                    nextSquareIndex += 8;
                    if (this.Board[nextSquareIndex].Piece == null)
                        this.ValidMoves.Add(this.Board[nextSquareIndex]);
                }
            }
        }

    }
}
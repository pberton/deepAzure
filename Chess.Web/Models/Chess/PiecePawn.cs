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

            char x =  this.Square.X;
            char y = this.Square.Y;
            char nextSquareIndex = y;

            if (this.Color == PieceColor.White)
            {
                nextSquareIndex ++;
                if (this.Board.IsEmptySquare(x, nextSquareIndex))
                    this.AddValidMove(x, nextSquareIndex);
                if (y == '2')
                {
                    nextSquareIndex++;
                    if (this.Board.IsEmptySquare(x, nextSquareIndex))
                        this.AddValidMove(x, nextSquareIndex);
                }
            }
            else
            {
                nextSquareIndex -= y;
                if (this.Board.IsEmptySquare(x, nextSquareIndex))
                    this.AddValidMove(x, nextSquareIndex);
                if (y == '7')
                {
                    nextSquareIndex--;
                    if (this.Board.IsEmptySquare(x, nextSquareIndex))
                        this.AddValidMove(x, nextSquareIndex);
                }
            }
        }

    }
}
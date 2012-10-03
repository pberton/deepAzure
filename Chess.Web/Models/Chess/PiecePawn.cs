using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class PiecePawn : PieceBase
    {
        public PiecePawn(PieceColor color)
        {
            this.Color = color;
        }

        public override void CalculateValidMoves()
        {
            this.ValidMoves.Clear();

            char x =  this.Square.X;
            char y = this.Square.Y;
            char nextYIndex = y;
            char leftXIndex = (char)(x - 1);
            char rightXIndex = (char)(x + 1);

            if (this.Color == PieceColor.White)
            {
                nextYIndex ++;
                if (this.Board.IsEmptySquare(x, nextYIndex))
                    this.AddValidMove(x, nextYIndex);

                CheckForCapture(leftXIndex, rightXIndex, nextYIndex, PieceColor.Black);

                if (y == '2')
                {
                    nextYIndex++;
                    if (this.Board.IsEmptySquare(x, nextYIndex))
                        this.AddValidMove(x, nextYIndex);
                }
            }
            else
            {
                nextYIndex --;
                if (this.Board.IsEmptySquare(x, nextYIndex))
                    this.AddValidMove(x, nextYIndex);

                CheckForCapture(leftXIndex, rightXIndex, nextYIndex, PieceColor.White);

                if (y == '7')
                {
                    nextYIndex--;
                    if (this.Board.IsEmptySquare(x, nextYIndex))
                        this.AddValidMove(x, nextYIndex);
                }
            }
        }

        private void CheckForCapture(char leftX, char rightX, char y, PieceColor color)
        {
            if (this.Board.IsOccupiedSquare(leftX, y, color))
            {
                this.AddValidMove(leftX, y);
            }

            if (this.Board.IsOccupiedSquare(rightX, y, color))
            {
                this.AddValidMove(rightX, y);
            }
        }

    }
}
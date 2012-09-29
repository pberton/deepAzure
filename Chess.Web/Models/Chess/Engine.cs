using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public class Engine: IEngine
    {
        Board board = new Board();

        public Engine()
        { 
        
        }

        public void LoadPiecesFromArray(string[] whitePieces, string[] blackPieces)
        {
            char type, x, y;

            foreach (string pieceText in whitePieces)
            {
                ReadPiece(pieceText, out type, out x, out y);
                board.LoadPiece(x, y, type, PieceColor.White);
            }

            foreach (string pieceText in blackPieces)
            {
                ReadPiece(pieceText, out type, out x, out y);
                board.LoadPiece(x, y, type, PieceColor.Black);
            }

            board.CalculateValidMoves();
        }

        private void ReadPiece(string pieceText, out char type, out char x, out char y)
        {
            if (pieceText.Length == 2)
            {
                type = ' ';
                x = pieceText[0];
                y = pieceText[1];
            }
            else
            {
                type = pieceText[0];
                x = pieceText[1];
                y = pieceText[2];
            }
        }

        public bool IsValidMove(string from, string to)
        {
            var piece = board.GetPieceFrom(from[0], from [1]);
            if (piece != null)
            {
                return piece.IsValidMove(to[0], to[1]);
            }
            else
            {
                return false;
            }
        }
    }
}
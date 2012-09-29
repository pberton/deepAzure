using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Web.Models.Chess
{
    public interface IEngine
    {
        void LoadPiecesFromArray(string[] whitePieces, string[] blackPieces);

        bool IsValidMove(string from, string to);
    }
}
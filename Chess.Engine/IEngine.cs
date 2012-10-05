using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Engine
{
    public interface IEngine
    {
        void LoadBoardFromArray(string[] whitePieces, string[] blackPieces);

        bool IsValidMove(string from, string to);

        bool Move(string from, string to);

        Board Board {get;}
    }
}
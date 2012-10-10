using Chess.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Chess.Web.Services
{
    public class ChessEngine : IChessEngine
    {
        public MoveResponse Move(MoveRequest request)
        {
            IEngine engine = new BasicEngine();
            engine.LoadBoard(request.Board.WhitePieces, request.Board.BlackPieces);

            MoveResponse resp = new MoveResponse();

            var move = engine.Move(request.From, request.To);
            if (move != null)
            {
                resp.IsValid = true;
                resp.IsCapture = move.IsCapture;

                if (move.EnPassant != null)
                    resp.EnPassantSquare = string.Concat(move.EnPassant.X, move.EnPassant.Y);
            }
            else
            {
                resp.IsValid = false;
            }
            return resp;
        }
    }
}

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
            engine.LoadBoard(request.Board.WhitePieces, request.Board.BlackPieces, request.Board.EnPassantSquare);

            engine.CalculateValidMoves((PieceColor)request.PlayerColor);

            MoveResponse resp = new MoveResponse();

            var move = engine.Move(request.From, request.To);
            if (move != null)
            {
                resp.IsValid = true;
                resp.IsCapture = move.IsCapture;
                
                if (move.CapturedPiece != null)
                    resp.CapturedPieceSquare = move.CapturedPiece.Square.ToString();

                if (move.EnPassant != null)
                    resp.EnPassantSquare = move.EnPassant.ToString();

                resp.IsPromotion = move.IsPromotion;
            }
            else
            {
                resp.IsValid = false;
            }
            return resp;
        }
    }
}

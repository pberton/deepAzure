///<reference path='../jquery.d.ts' />
///<reference path='Board.ts' />
///<reference path='Services/ChessEngine.ts' />

class Game {
    private _board: Board;
    private _whitePlayer: Player;
    private _blackPlayer: Player;
    private _log: string[];

    private _playerToPlay: Player;
    private _nextPlayerToPlay: Player;
  
    private _onLog : (data: string) => void;

    constructor (board: Board) {
        this._whitePlayer = new Player(0, board);
        this._blackPlayer = new Player(1, board);

        this._board = board;
    }
    
    getLog(): string[] {
        return this._log; 
    }

    onLog(callback : (data: string) => void) : void {
        this._onLog = callback;
    }

    startNewGame() : void {
        this._log = new string[]();

        this._whitePlayer.setStartPosition();
        this._blackPlayer.setStartPosition();

        this._playerToPlay = this._whitePlayer;
        this._nextPlayerToPlay = this._blackPlayer;
    }

    moveById(targetId: string) : void {
        var square = this._board.getSquareById(targetId);
        this.moveTo(square);
    }

    action(x, y) : void {
        if (this._playerToPlay.getSelectedPiece() != null) {
            var square = this._board.getSelectedSquare(x, y);
            if (square.getPiece() != null && square.getPiece().getPlayer() == this._playerToPlay) {
                this._playerToPlay.selectPiece(x, y);
            }
            else {
                this.moveTo(square);
            }
        }
        else {
            this._playerToPlay.selectPiece(x, y);
        }
    }
    
    moveTo(toSquare: BoardSquare) : void {
        var currentPlayer = this._playerToPlay;
        var nextPlayer = this._nextPlayerToPlay;
        var piece = currentPlayer.getSelectedPiece();
        var fromSquare = piece.getSquare();

        if (piece != null && toSquare != null) {
            this.evaluateMove(piece, toSquare, 
                (resp) => {
                    if (resp.IsValid) {
                        currentPlayer.move(piece, toSquare);
                        
                        if (resp.EnPassantSquare != null)
                            alert(resp.EnPassantSquare);

                        this._playerToPlay = nextPlayer;
                        this._nextPlayerToPlay = currentPlayer;
                        
                        this.logPieceMove(piece, fromSquare, toSquare, resp.IsCapture);
                    }
                },
                this.logError
            );
        }
    }

    private evaluateMove(piece: Piece, square: BoardSquare, callback: (resp: Services.IMoveResponse) => void , errorCallback: (status: string) => void ): void {
        var request: Services.IMoveRequest = {
            Board: {
                WhitePieces: this._whitePlayer.getPiecesAsStrings(),
                BlackPieces: this._blackPlayer.getPiecesAsStrings()
            },
            From: piece.getPosition(),
            To: square.getId()
        }
        Services.ChessEngine.move(request,callback,errorCallback);
    }

    private logError(message: string): void
    { 
        alert(message);
    }

    private logPieceMove(piece: Piece, from: BoardSquare, to: BoardSquare, isCapture: bool) : void {
        var text = piece.getType();
        if (isCapture) {
            if (piece.getType() == "")
                text += from.getId()[0];
            text += "x";
        }
        text += to.getId();
        
        this._log.push(text);

        if (this._onLog!=null)
            this._onLog(text);
    }   
}
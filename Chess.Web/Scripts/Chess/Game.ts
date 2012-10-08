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

    moveTo(square: BoardSquare) : void {
        var currentPlayer = this._playerToPlay;
        var nextPlayer = this._nextPlayerToPlay;
        var piece = currentPlayer.getSelectedPiece();

        if (piece != null && square != null) {
            this.evaluateValidMove(piece, square, 
                (isValid) => {
                    if (isValid) {
                        var result = currentPlayer.move(piece, square);
                        if (result) {
                            this._playerToPlay = nextPlayer;
                            this._nextPlayerToPlay = currentPlayer;
                            this.logPieceMove(piece);
                        }
                    }
                },
                status => alert(status)
            );
        }
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

    private evaluateValidMove(piece: Piece, square: BoardSquare, callback : (isValid: bool) => void, errorCallback : (status: string) => void) : void {
        var request : Services.IMoveRequest = {
            WhitePieces: this._whitePlayer.getPiecesAsStrings(), BlackPieces: this._blackPlayer.getPiecesAsStrings(),
            From: piece.getPosition(), To: square.getId()
        }
        Services.ChessEngine.isValidMode(request,callback,errorCallback);
    }

    private logPieceMove(piece: Piece) : void {
        var text = piece.getType() + piece.getSquare().getId();
        this._log.push(text);

        if (this._onLog!=null)
            this._onLog(text);
    }   
}
///<reference path='../jquery.d.ts' />
///<reference path='Board.ts' />

class Game {
    private board: Board;
    private whitePlayer: Player;
    private blackPlayer: Player;

    private playerToPlay: Player;
    private nextPlayerToPlay: Player;

    constructor (board: Board) {
        this.whitePlayer = new Player(0, board);
        this.blackPlayer = new Player(1, board);

        this.board = board;
    }

    startNewGame() {
        this.whitePlayer.setStartPosition();
        this.blackPlayer.setStartPosition();

        this.playerToPlay = this.whitePlayer;
        this.nextPlayerToPlay = this.blackPlayer;
    }

    moveById(targetId: string) {
        var square = this.board.getSquareById(targetId);
        this.moveTo(square);
    }

    moveTo(square: BoardSquare) {
        var currentPlayer = this.playerToPlay;
        var nextPlayer = this.nextPlayerToPlay;
        var piece = currentPlayer.getSelectedPiece();
        var game = this;

        if (piece != null && square != null) {
            this.evaluateValidMove(piece, square, 
                function (isValid) {
                    if (isValid) {
                        var result = currentPlayer.move(piece, square);
                        if (result) {
                            game.playerToPlay = nextPlayer;
                            game.nextPlayerToPlay = currentPlayer
                        }
                    }
                },
                function (e) { alert(e.statusText) }
            );
        }
    }

    action(x, y) {
        if (this.playerToPlay.getSelectedPiece() != null) {
            var square = this.board.getSelectedSquare(x, y);
            if (square.getPiece() != null && square.getPiece().getPlayer() == this.playerToPlay) {
                this.playerToPlay.selectPiece(x, y);
            }
            else {
                this.moveTo(square);
            }
        }
        else {
            this.playerToPlay.selectPiece(x, y);
        }
    }

    evaluateValidMove(piece: Piece, square: BoardSquare, callback, errorCallback)  {
        var request = {
            WhitePieces: this.whitePlayer.getPiecesAsStrings(), BlackPieces: this.blackPlayer.getPiecesAsStrings(),
            From: piece.getPosition(), To: square.getId()
        }
        var settings: JQueryAjaxSettings = {
            type: "POST", 
            contentType: "application/json",
            data: JSON.stringify(request),
            dataType: "json",
            success: callback,
            error: errorCallback
        }

        $.ajax("/Services/ChessEngine.svc/IsValidMove",settings);
    }
}
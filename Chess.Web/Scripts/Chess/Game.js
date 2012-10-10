var Game = (function () {
    function Game(board) {
        this._whitePlayer = new Player(0, board);
        this._blackPlayer = new Player(1, board);
        this._board = board;
    }
    Game.prototype.getLog = function () {
        return this._log;
    };
    Game.prototype.onLog = function (callback) {
        this._onLog = callback;
    };
    Game.prototype.startNewGame = function () {
        this._log = new Array();
        this._whitePlayer.setStartPosition();
        this._blackPlayer.setStartPosition();
        this._playerToPlay = this._whitePlayer;
        this._nextPlayerToPlay = this._blackPlayer;
    };
    Game.prototype.moveById = function (targetId) {
        var square = this._board.getSquareById(targetId);
        this.moveTo(square);
    };
    Game.prototype.action = function (x, y) {
        if(this._playerToPlay.getSelectedPiece() != null) {
            var square = this._board.getSelectedSquare(x, y);
            if(square.getPiece() != null && square.getPiece().getPlayer() == this._playerToPlay) {
                this._playerToPlay.selectPiece(x, y);
            } else {
                this.moveTo(square);
            }
        } else {
            this._playerToPlay.selectPiece(x, y);
        }
    };
    Game.prototype.moveTo = function (toSquare) {
        var _this = this;
        var currentPlayer = this._playerToPlay;
        var nextPlayer = this._nextPlayerToPlay;
        var piece = currentPlayer.getSelectedPiece();
        var fromSquare = piece.getSquare();
        if(piece != null && toSquare != null) {
            this.evaluateMove(piece, toSquare, function (resp) {
                if(resp.IsValid) {
                    currentPlayer.move(piece, toSquare);
                    if(resp.EnPassantSquare != null) {
                        alert(resp.EnPassantSquare);
                    }
                    _this._playerToPlay = nextPlayer;
                    _this._nextPlayerToPlay = currentPlayer;
                    _this.logPieceMove(piece, fromSquare, toSquare, resp.IsCapture);
                }
            }, this.logError);
        }
    };
    Game.prototype.evaluateMove = function (piece, square, callback, errorCallback) {
        var request = {
            Board: {
                WhitePieces: this._whitePlayer.getPiecesAsStrings(),
                BlackPieces: this._blackPlayer.getPiecesAsStrings()
            },
            From: piece.getPosition(),
            To: square.getId()
        };
        Services.ChessEngine.move(request, callback, errorCallback);
    };
    Game.prototype.logError = function (message) {
        alert(message);
    };
    Game.prototype.logPieceMove = function (piece, from, to, isCapture) {
        var text = piece.getType();
        if(isCapture) {
            if(piece.getType() == "") {
                text += from.getId()[0];
            }
            text += "x";
        }
        text += to.getId();
        this._log.push(text);
        if(this._onLog != null) {
            this._onLog(text);
        }
    };
    return Game;
})();

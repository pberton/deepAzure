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
    Game.prototype.moveTo = function (square) {
        var _this = this;
        var currentPlayer = this._playerToPlay;
        var nextPlayer = this._nextPlayerToPlay;
        var piece = currentPlayer.getSelectedPiece();
        if(piece != null && square != null) {
            this.evaluateValidMove(piece, square, function (isValid) {
                if(isValid) {
                    var result = currentPlayer.move(piece, square);
                    if(result) {
                        _this._playerToPlay = nextPlayer;
                        _this._nextPlayerToPlay = currentPlayer;
                        _this.logPieceMove(piece);
                    }
                }
            }, function (status) {
                return alert(status);
            });
        }
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
    Game.prototype.evaluateValidMove = function (piece, square, callback, errorCallback) {
        var request = {
            WhitePieces: this._whitePlayer.getPiecesAsStrings(),
            BlackPieces: this._blackPlayer.getPiecesAsStrings(),
            From: piece.getPosition(),
            To: square.getId()
        };
        Services.ChessEngine.isValidMode(request, callback, errorCallback);
    };
    Game.prototype.logPieceMove = function (piece) {
        var text = piece.getType() + piece.getSquare().getId();
        this._log.push(text);
        if(this._onLog != null) {
            this._onLog(text);
        }
    };
    return Game;
})();

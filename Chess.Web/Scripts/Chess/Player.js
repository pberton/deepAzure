var Player = (function () {
    function Player(id, board) {
        this._id = id;
        this._board = board;
    }
    Player.prototype.getId = function () {
        return this._id;
    };
    Player.prototype.setStartPosition = function () {
        if(this._id == 0) {
            this.setPiece("R", "a1");
            this.setPiece("N", "b1");
            this.setPiece("B", "c1");
            this.setPiece("Q", "d1");
            this.setPiece("K", "e1");
            this.setPiece("B", "f1");
            this.setPiece("N", "g1");
            this.setPiece("R", "h1");
            this.setPiece("", "a2");
            this.setPiece("", "b2");
            this.setPiece("", "c2");
            this.setPiece("", "d2");
            this.setPiece("", "e2");
            this.setPiece("", "f2");
            this.setPiece("", "g2");
            this.setPiece("", "h2");
        } else {
            this.setPiece("R", "a8");
            this.setPiece("N", "b8");
            this.setPiece("B", "c8");
            this.setPiece("K", "d8");
            this.setPiece("Q", "e8");
            this.setPiece("B", "f8");
            this.setPiece("N", "g8");
            this.setPiece("R", "h8");
            this.setPiece("", "a7");
            this.setPiece("", "b7");
            this.setPiece("", "c7");
            this.setPiece("", "d7");
            this.setPiece("", "e7");
            this.setPiece("", "f7");
            this.setPiece("", "g7");
            this.setPiece("", "h7");
        }
    };
    Player.prototype.setPiece = function (type, position) {
        var square = this._board.getSquareById(position);
        if(square != null) {
            var piece = new Piece(this, type);
            piece.setSquare(square);
        }
    };
    Player.prototype.move = function (piece, square) {
        var originalSquare = piece.getSquare();
        var capturedPiece = square.getPiece();
        if(capturedPiece != null) {
            capturedPiece.setSquare(null);
        }
        piece.setSquare(square);
        originalSquare.setSelected(false);
        piece.setSelected(false);
        this._board.drawSquare(originalSquare);
        this._board.drawSquare(square);
        return true;
    };
    Player.prototype.getSelectedPiece = function () {
        var selectedPiece = null;
        $.each(this.getPieces(), function (index, piece) {
            if(piece.getSelected()) {
                selectedPiece = piece;
            }
        });
        return selectedPiece;
    };
    Player.prototype.selectPiece = function (x, y) {
        var board = this._board;
        var square = board.getSelectedSquare(x, y);
        if(square != null) {
            var pieceInSquare = square.getPiece();
            if(pieceInSquare != null) {
                $.each(this.getPieces(), function (index, piece) {
                    if(piece == pieceInSquare) {
                        piece.setSelected(true);
                        board.selectSquare(piece.getSquare());
                    } else {
                        piece.setSelected(false);
                    }
                });
            }
        }
    };
    Player.prototype.getPiecesAsStrings = function () {
        var piecesAsString = new Array();
        $.each(this.getPieces(), function (index, piece) {
            var str = piece.getType() + piece.getPosition();
            piecesAsString.push(str);
        });
        return piecesAsString;
    };
    Player.prototype.getPieces = function () {
        var _this = this;
        var pieces = new Array();
        $.each(this._board.getSquares(), function (index, square) {
            var piece = square.getPiece();
            if(piece != null && piece.getPlayer() == _this) {
                pieces.push(piece);
            }
        });
        return pieces;
    };
    return Player;
})();

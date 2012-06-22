function Player(id, board) {
    this.color = (id == 0 ? "White" : "Black"); ;
    this.id = id;
    this.board = board;
    this.pieces = new Array();
}

Player.prototype.getId = (function() {
    return this.id;
})

Player.prototype.getColor = (function () {
    return this.color;
})

Player.prototype.setStartPosition = (function () {
    this.pieces = new Array();
    // Set pieces to start position
    if (this.id == 0) {
        this.setPiece("R", "a1");
        this.setPiece("N", "b1");
        this.setPiece("B", "c1");
        this.setPiece("Q", "d1");
        this.setPiece("K", "e1");
        this.setPiece("B", "f1");
        this.setPiece("N", "g1");
        this.setPiece("R", "h1");
        // pawns
        this.setPiece("", "a2");
        this.setPiece("", "b2");
        this.setPiece("", "c2");
        this.setPiece("", "d2");
        this.setPiece("", "e2");
        this.setPiece("", "f2");
        this.setPiece("", "g2");
        this.setPiece("", "h2");
    }
    else {
        this.setPiece("R", "a8");
        this.setPiece("N", "b8");
        this.setPiece("B", "c8");
        this.setPiece("K", "d8");
        this.setPiece("Q", "e8");
        this.setPiece("B", "f8");
        this.setPiece("N", "g8");
        this.setPiece("R", "h8");
        // pawns
        this.setPiece("", "a7");
        this.setPiece("", "b7");
        this.setPiece("", "c7");
        this.setPiece("", "d7");
        this.setPiece("", "e7");
        this.setPiece("", "f7");
        this.setPiece("", "g7");
        this.setPiece("", "h7");
    }
})

Player.prototype.setPiece = (function (type, position) {
    var square = this.board.getSquareById(position);
    if (square != null) {
        var piece = new Piece(this, type);
        piece.setSquare(square);
        this.pieces[this.pieces.length] = piece;
    }
})

Player.prototype.move = (function (piece, square) {
    if (square.getPiece() == null) {
        var originalSquare = piece.getSquare();
        piece.setSquare(square);
        originalSquare.setSelected(false);
        piece.setSelected(false);

        this.board.drawSquare(originalSquare);
        this.board.drawSquare(piece.getSquare());
        return true;
    }
    return false;
})

Player.prototype.getSelectedPiece = (function () {
    for (var i = 0; i < this.pieces.length; i++) {
        if (this.pieces[i].getSelected())
            return this.pieces[i];
    }
    return null;
})

Player.prototype.selectPiece = (function (x, y) {
    var square = this.board.getSelectedSquare(x, y);
    if (square != null) {
        var piece = square.getPiece();
        if (piece != null) {
            for (var i = 0; i < this.pieces.length; i++) {
                if (this.pieces[i] == piece) {
                    piece.setSelected(true);
                    board.selectSquare(square);
                }
                else {
                    this.pieces[i].setSelected(false);
                }
            }
        }
    }
})




function Game(board) {
    this.whitePlayer = new Player(0, board);
    this.blackPlayer = new Player(1, board);

    this.board = board;
}

Game.prototype.startNewGame = (function () {
    this.whitePlayer.setStartPosition();
    this.blackPlayer.setStartPosition();

    this.playerToPlay = this.whitePlayer;
    this.nextPlayerToPlay = this.blackPlayer;
})

Game.prototype.moveById = (function (targetId) {
    var square = this.board.getSquareById(targetId);
    this.moveTo(square);
})

Game.prototype.moveTo = (function (square) {
    var currentPlayer = this.playerToPlay;
    var piece = currentPlayer.getSelectedPiece();

    if (piece != null && square != null) {
        var result = currentPlayer.move(piece, square);
        if (result) {
            this.playerToPlay = this.nextPlayerToPlay;
            this.nextPlayerToPlay = currentPlayer
        }
    }
})

Game.prototype.action = (function (x, y) {
    if (this.playerToPlay.getSelectedPiece() != null) {
        var square = this.board.getSelectedSquare(x, y);
        this.moveTo(square);
    }
    else {
        this.playerToPlay.selectPiece(x, y);
    }
})
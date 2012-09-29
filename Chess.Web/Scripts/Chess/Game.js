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
    var nextPlayer = this.nextPlayerToPlay;
    var piece = currentPlayer.getSelectedPiece();
    var game = this;

    if (piece != null && square != null) {
        this.isValidMove(piece, square, function (isValid) {
            if (isValid) {
                var result = currentPlayer.move(piece, square);
                if (result) {
                    game.playerToPlay = nextPlayer;
                    game.nextPlayerToPlay = currentPlayer
                }
            }
        });
    }
})

Game.prototype.action = (function (x, y) {
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
})

Game.prototype.isValidMove = (function (piece, square, func) {
    var request = { WhitePieces: this.whitePlayer.getPiecesAsStrings(), BlackPieces: this.blackPlayer.getPiecesAsStrings(), 
            From: piece.getPosition(), To: square.getId() }
    $.ajax({
                url: "/Services/ChessEngine.svc/IsValidMove",
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(request),
                dataType: "json",
                success: func,
                error: function(e) { alert(e.statusText); }
            });
})
///<reference path='Board.ts' />

class Player {
    private color: string;
    private id: number;
    private board: Board;

    constructor (id: number, board: Board) {
        this.color = (id == 0 ? "White" : "Black");
        this.id = id;
        this.board = board;
    }

    getId() : number {
        return this.id;
    }

    getColor() : string {
        return this.color;
    }

    setStartPosition() {
        //this.pieces = new Piece[]()
        // Set pieces to start position
        if(this.id == 0) {
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
    }

    setPiece(type : string, position : string) {
        var square = this.board.getSquareById(position);
        if (square != null) {
            var piece = new Piece(this, type);
            piece.setSquare(square);
        }
    }

    move(piece: Piece, square: BoardSquare) : bool {
        var originalSquare = piece.getSquare();

        var capturedPiece = square.getPiece();
        if (capturedPiece != null) {
            capturedPiece.setSquare(null);
        }

        piece.setSquare(square);
        originalSquare.setSelected(false);
        piece.setSelected(false);

        this.board.drawSquare(originalSquare);
        this.board.drawSquare(square);
        return true;
    }

    getSelectedPiece() : Piece {
        var selectedPiece: Piece = null;
        $.each(this.getPieces(), function (index, piece) {
               if (piece.getSelected())
                selectedPiece = piece;
        });
        return selectedPiece;
    }

    selectPiece(x: number, y: number) {
        var board = this.board;
        var square = board.getSelectedSquare(x, y);
        if (square != null) {
            var pieceInSquare = square.getPiece();
            if (pieceInSquare != null) {
                 $.each(this.getPieces(), function (index: number, piece: Piece) {
                     if (piece == pieceInSquare) {
                         piece.setSelected(true);
                         board.selectSquare(piece.getSquare());
                     }
                     else {
                         piece.setSelected(false);
                     }
                });
            }
        }
    }

    getPiecesAsStrings(): string[] {
        var piecesAsString: string[] = new string[];
        $.each(this.getPieces(), function (index: number, piece: Piece) {
            var str = piece.getType() + piece.getPosition();
            piecesAsString.push(str);
        });
        return piecesAsString;
    }
    
    getPieces(): Piece[] {
        var pieces: Piece[] = new Piece[];
        var currentPlayer = this;
        $.each(this.board.getSquares(), (index: number, square: BoardSquare) {
            var piece = square.getPiece();
            if (piece!= null && piece.getPlayer() == currentPlayer)
                pieces[pieces.length] = piece;
        });
        return pieces;
    }
}
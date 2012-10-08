///<reference path='../jquery.d.ts' />
///<reference path='BoardSquare.ts' />

class Board {
    static DarkColor: string = "#A8864A";
    static LightColor: string = "#F0E0C5";
    static SelectedColor: string = "#7E1BE0";
    static SquareSize: number = 45;

    private _canvas: HTMLCanvasElement;
    private _context: CanvasRenderingContext2D;
    private _squares: BoardSquare[] = new BoardSquare[]();
    private _scaleRatio: number = 1;
    private _canvasSize: number;

    constructor (canvas: HTMLCanvasElement) {
        this._canvas = canvas;
        this._context = this._canvas.getContext("2d");

        var counter = 0;
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var x = Board.SquareSize * i;
                var y = Board.SquareSize * j;
                var fillStyle = ((i + j) % 2 != 0) ? Board.DarkColor : Board.LightColor;
                this._squares.push(new BoardSquare(Board.getSquareId(i, j), x, y, Board.SquareSize, fillStyle));
                counter++;
            }
        }
    }

    static getSquareId(i: number, j: number): string {
        return String.fromCharCode(97 + i) + ((j - 8) * -1)
    }

    getSquares(): BoardSquare[] {
        return this._squares;
    }

    getCanvasSize() : number {
        return Math.min($(window).width()  - 15, $(window).height()  - 100);
    }

    draw() : void {
        this._canvasSize = this.getCanvasSize();
        this._canvas.width = this._canvasSize;
        this._canvas.height = this._canvasSize;

        this.scale();

        this._context.strokeStyle = Board.DarkColor;
        this._context.fillStyle = Board.LightColor;
        this._context.fillRect(0, 0, length, length);

        for (var i = 0; i < this._squares.length; i++) {
            this.drawSquare(this._squares[i]);
        }

        this._context.strokeRect(0, 0, length, length);
    }

    getSquareById(id: string) : BoardSquare {
        for (var i = 0; i < this._squares.length; i++) {
            var square = this._squares[i];
            if (square.getId() == id)
                return square;
        }
    }

    drawSquare(square: BoardSquare) : void {
        square.draw(this._context);
    }

    scale() : void {
        var length = Board.SquareSize << 3;
        this._scaleRatio = this._canvasSize / length;
        this._context.scale(this._scaleRatio, this._scaleRatio);
    }

    selectSquare(selected: BoardSquare) : void {
        for (var i = 0; i < this._squares.length; i++) {
            var square = this._squares[i];
            if (square == selected) {
                square.setSelected(true);
                square.draw(this._context);
            }
            else {
                if (square.getSelected()) {
                    square.setSelected(false);
                    square.draw(this._context);
                }
            }
        }
    }

    getSelectedSquare(x: number, y: number) : BoardSquare {
        var scaledX = x / this._scaleRatio;
        var scaledY = y / this._scaleRatio;
        var squareLength = Board.SquareSize;

        for (var i = 0; i < this._squares.length; i++) {
            var square = this._squares[i];
            if (square.getX() < scaledX && square.getX() > (scaledX - squareLength)
                && square.getY() < scaledY && square.getY() > (scaledY - squareLength)) {
                return square;
            }
        }
        return null;
    }
}
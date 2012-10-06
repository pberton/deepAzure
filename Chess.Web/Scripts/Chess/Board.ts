///<reference path='../jquery.d.ts' />
///<reference path='BoardSquare.ts' />

class Board {
    static DarkColor: string = "#A8864A";
    static LightColor: string = "#F0E0C5";
    static SelectedColor: string = "#7E1BE0";
    static SquareSize: number = 45;

    private canvas: HTMLCanvasElement;
    private context: CanvasRenderingContext2D;
    private squares: BoardSquare[] = new BoardSquare[]();
    private scaleRatio: number = 1;
    private canvasSize: number;

    constructor (canvas: HTMLCanvasElement) {
        this.canvas = canvas;
        this.context = this.canvas.getContext("2d");

        var counter = 0;
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var x = Board.SquareSize * i;
                var y = Board.SquareSize * j;
                var fillStyle = ((i + j) % 2 != 0) ? Board.DarkColor : Board.LightColor;
                this.squares[counter] = new BoardSquare(Board.getSquareId(i, j), x, y, Board.SquareSize, fillStyle);
                counter++;
            }
        }
    }

    static getSquareId(i: number, j: number): string {
        return String.fromCharCode(97 + i) + ((j - 8) * -1)
    }

    getSquares(): BoardSquare[] {
        return this.squares;
    }

    getCanvasSize() : number {
        return Math.min($(window).width(), $(window).height()) - 15;
    }

    draw() {
        this.canvasSize = this.getCanvasSize();
        this.canvas.width = this.canvasSize;
        this.canvas.height = this.canvasSize;

        this.scale();

        this.context.strokeStyle = Board.DarkColor;
        this.context.fillStyle = Board.LightColor;
        this.context.fillRect(0, 0, length, length);

        for (var i = 0; i < this.squares.length; i++) {
            this.drawSquare(this.squares[i]);
        }

        this.context.strokeRect(0, 0, length, length);
    }

    getSquareById(id: string) : BoardSquare {
        for (var i = 0; i < this.squares.length; i++) {
            var square = this.squares[i];
            if (square.getId() == id)
                return square;
        }
    }

    drawSquare(square: BoardSquare) {
        square.draw(this.context);
    }

    scale() {
        var length = Board.SquareSize << 3;
        this.scaleRatio = this.canvasSize / length;
        this.context.scale(this.scaleRatio, this.scaleRatio);
    }

    selectSquare(selected: BoardSquare) {
        for (var i = 0; i < this.squares.length; i++) {
            var square = this.squares[i];
            if (square == selected) {
                square.setSelected(true);
                square.draw(this.context);
            }
            else {
                if (square.getSelected()) {
                    square.setSelected(false);
                    square.draw(this.context);
                }
            }
        }
    }

    getSelectedSquare(x: number, y: number) : BoardSquare {
        var scaledX = x / this.scaleRatio;
        var scaledY = y / this.scaleRatio;
        var squareLength = Board.SquareSize;

        for (var i = 0; i < this.squares.length; i++) {
            var square = this.squares[i];
            if (square.getX() < scaledX && square.getX() > (scaledX - squareLength)
                && square.getY() < scaledY && square.getY() > (scaledY - squareLength)) {
                return square;
            }
        }
        return null;
    }
}
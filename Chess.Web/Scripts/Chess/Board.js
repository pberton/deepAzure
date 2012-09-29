Board.DarkColor = "#A8864A";
Board.LightColor = "#F0E0C5";
Board.SelectedColor = "#7E1BE0";
Board.SquareSize = 45;

function Board(canvas) {
    this.canvas = canvas;
    this.context = this.canvas.getContext("2d");
    this.squares = new Array();
    this.scaleRatio = 1;

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

Board.getSquareId = (function(i, j) { 
    return String.fromCharCode(97 + i) + ((j - 8)*-1)
})

Board.prototype.getCanvasSize = (function () {
    return Math.min($(window).width(), $(window).height()) - 15;
})

Board.prototype.draw = (function () {
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
})

Board.prototype.getSquareById = (function (id) {
    for (var i = 0; i < this.squares.length; i++) {
        var square = this.squares[i];
        if (square.getId() == id)
            return square;
    }
})

Board.prototype.drawSquare = (function (square) {
    square.draw(this.context);
})

Board.prototype.scale = (function() {
    var length = Board.SquareSize << 3;
    this.scaleRatio = this.canvasSize / length;
    this.context.scale(this.scaleRatio, this.scaleRatio);
})

Board.prototype.selectSquare = (function (selected) {  
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
})

Board.prototype.getSelectedSquare = (function (x, y) {
    var scaledX = x / this.scaleRatio;
    var scaledY = y / this.scaleRatio;
    var squareLength = Board.SquareSize;

    for (var i = 0; i < this.squares.length; i++) {
        var square = this.squares[i];
        if (square.x < scaledX && square.x > (scaledX - squareLength)
            && square.y < scaledY && square.y > (scaledY - squareLength)) {
            return square;
        }
    }
    return null;
})


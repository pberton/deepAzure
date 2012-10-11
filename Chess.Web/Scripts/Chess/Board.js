var Board = (function () {
    function Board(canvas) {
        this._squares = new Array();
        this._scaleRatio = 1;
        this._canvas = canvas;
        this._context = this._canvas.getContext("2d");
        var counter = 0;
        for(var i = 0; i < 8; i++) {
            for(var j = 0; j < 8; j++) {
                var x = Board.SquareSize * i;
                var y = Board.SquareSize * j;
                var fillStyle = ((i + j) % 2 != 0) ? Board.DarkColor : Board.LightColor;
                this._squares.push(new BoardSquare(Board.getSquareId(i, j), x, y, Board.SquareSize, fillStyle));
                counter++;
            }
        }
    }
    Board.DarkColor = "#A8864A";
    Board.LightColor = "#F0E0C5";
    Board.SelectedColor = "#7E1BE0";
    Board.SquareSize = 45;
    Board.getSquareId = function getSquareId(i, j) {
        return String.fromCharCode(97 + i) + ((j - 8) * -1);
    }
    Board.prototype.getEnPassantSquare = function () {
        return this._enPassantSquare;
    };
    Board.prototype.setEnPassantSquare = function (square) {
        this._enPassantSquare = square;
    };
    Board.prototype.getSquares = function () {
        return this._squares;
    };
    Board.prototype.getCanvasSize = function () {
        return Math.min($(window).width() - 15, $(window).height() - 100);
    };
    Board.prototype.draw = function () {
        this._canvasSize = this.getCanvasSize();
        this._canvas.width = this._canvasSize;
        this._canvas.height = this._canvasSize;
        this.scale();
        this._context.strokeStyle = Board.DarkColor;
        this._context.fillStyle = Board.LightColor;
        this._context.fillRect(0, 0, length, length);
        for(var i = 0; i < this._squares.length; i++) {
            this.drawSquare(this._squares[i]);
        }
        this._context.strokeRect(0, 0, length, length);
    };
    Board.prototype.getSquareById = function (id) {
        for(var i = 0; i < this._squares.length; i++) {
            var square = this._squares[i];
            if(square.getId() == id) {
                return square;
            }
        }
    };
    Board.prototype.drawSquare = function (square) {
        square.draw(this._context);
    };
    Board.prototype.scale = function () {
        var length = Board.SquareSize << 3;
        this._scaleRatio = this._canvasSize / length;
        this._context.scale(this._scaleRatio, this._scaleRatio);
    };
    Board.prototype.selectSquare = function (selected) {
        for(var i = 0; i < this._squares.length; i++) {
            var square = this._squares[i];
            if(square == selected) {
                square.setSelected(true);
                square.draw(this._context);
            } else {
                if(square.getSelected()) {
                    square.setSelected(false);
                    square.draw(this._context);
                }
            }
        }
    };
    Board.prototype.getSelectedSquare = function (x, y) {
        var scaledX = x / this._scaleRatio;
        var scaledY = y / this._scaleRatio;
        var squareLength = Board.SquareSize;
        for(var i = 0; i < this._squares.length; i++) {
            var square = this._squares[i];
            if(square.getX() < scaledX && square.getX() > (scaledX - squareLength) && square.getY() < scaledY && square.getY() > (scaledY - squareLength)) {
                return square;
            }
        }
        return null;
    };
    return Board;
})();

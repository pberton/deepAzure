var BoardSquare = (function () {
    function BoardSquare(id, positionX, positionY, length, fillStyle) {
        this._id = id;
        this._x = positionX;
        this._y = positionY;
        this._length = length;
        this._fillStyle = fillStyle;
        this._selected = false;
        this._piece = null;
    }
    BoardSquare.prototype.getX = function () {
        return this._x;
    };
    BoardSquare.prototype.getY = function () {
        return this._y;
    };
    BoardSquare.prototype.getSelected = function () {
        return this._selected;
    };
    BoardSquare.prototype.setSelected = function (val) {
        this._selected = val;
    };
    BoardSquare.prototype.getId = function () {
        return this._id;
    };
    BoardSquare.prototype.getPiece = function () {
        return this._piece;
    };
    BoardSquare.prototype.setPiece = function (piece) {
        this._piece = piece;
    };
    BoardSquare.prototype.draw = function (ctx) {
        ctx.save();
        if(this._selected) {
            ctx.fillStyle = Board.SelectedColor;
        } else {
            ctx.fillStyle = this._fillStyle;
        }
        ctx.fillRect(this._x, this._y, this._length, this._length);
        if(this._piece != null) {
            this._piece.draw(ctx, this._x, this._y);
        } else {
            ctx.fillStyle = "black";
            ctx.fillText(this._id, (this._x + this._length / 2 - 5), (this._y + this._length / 2 + 5));
        }
        ctx.restore();
    };
    return BoardSquare;
})();

function BoardSquare(id, positionX, positionY, length, fillStyle) {
    this.id = id;
    this.x = positionX;
    this.y = positionY;
    this.length = length;
    this.fillStyle = fillStyle;
    this.selected = false;

    this.piece = null;
}

BoardSquare.prototype.getId = (function () {
    return this.id;
})

BoardSquare.prototype.getPiece = (function () {
    return this.piece;
})

BoardSquare.prototype.setPiece = (function (piece) {
    this.piece = piece;
})

BoardSquare.prototype.draw = (function (ctx) {
    ctx.save();

    if (this.selected) {
        ctx.fillStyle = Board.SelectedColor;
    }
    else {
        ctx.fillStyle = this.fillStyle;
    }

    ctx.fillRect(this.x, this.y, this.length, this.length);

    if (this.piece != null) {
        this.piece.draw(ctx, this.x, this.y);
    }
    else {
        ctx.fillStyle = "black";
        ctx.fillText(this.id, this.x + this.length / 2 - 5, this.y + this.length / 2 + 5);
    }

    ctx.restore();
})

BoardSquare.prototype.getSelected = (function () {
    return this.selected;
})

BoardSquare.prototype.setSelected = (function (val) {
    this.selected = val;
})
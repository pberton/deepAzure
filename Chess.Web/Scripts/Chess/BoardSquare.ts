///<reference path='Piece.ts' />

class BoardSquare {
    private _id: string;
    private _x: number;
    private _y: number;
    private _length: number;
    private _fillStyle: string;
    private _selected: bool;
    private _piece: Piece;

    constructor (id: string, positionX: number, positionY: number, length: number, fillStyle: string) {
        this._id = id;
        this._x = positionX;
        this._y = positionY;
        this._length = length;
        this._fillStyle = fillStyle;
        this._selected = false;

        this._piece = null;
    } 
    getX(): number
    {
        return this._x;
    }
    getY(): number
    {
        return this._y;
    }
    getSelected(): bool {
        return this._selected;
    }
    setSelected(val: bool) {
        this._selected = val;
    }
    getId() : string {
        return this._id;
    }
    getPiece(): Piece {
        return this._piece;
    }
    setPiece(piece: Piece) {
        this._piece = piece;
    }
    draw(ctx: CanvasRenderingContext2D) : void {
        ctx.save();

        if (this._selected) {
            ctx.fillStyle = Board.SelectedColor;
        }
        else {
            ctx.fillStyle = this._fillStyle;
        }

        ctx.fillRect(this._x, this._y, this._length, this._length);

        if (this._piece != null) {
            this._piece.draw(ctx, this._x, this._y);
        }
        else {
            ctx.fillStyle = "black";
            ctx.fillText(this._id, (this._x + this._length / 2 - 5), (this._y + this._length / 2 + 5));
        }

        ctx.restore();
    }
}
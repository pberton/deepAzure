///<reference path='Piece.ts' />

class BoardSquare {
    private id: string;
    private x: number;
    private y: number;
    private length: number;
    private fillStyle: string;
    private selected: bool;
    private piece: Piece;

    constructor (id: string, positionX: number, positionY: number, length: number, fillStyle: string) {
        this.id = id;
        this.x = positionX;
        this.y = positionY;
        this.length = length;
        this.fillStyle = fillStyle;
        this.selected = false;

        this.piece = null;
    }
    getX(): number
    {
        return this.x;
    }
    getY(): number
    {
        return this.y;
    }
    getSelected(): bool {
        return this.selected;
    }
    setSelected(val: bool) {
        this.selected = val;
    }
    getId() : string {
        return this.id;
    }
    getPiece(): Piece {
        return this.piece;
    }
    setPiece(piece: Piece) {
        this.piece = piece;
    }
    draw(ctx: CanvasRenderingContext2D) {
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
            ctx.fillText(this.id, (this.x + this.length / 2 - 5), (this.y + this.length / 2 + 5));
        }

        ctx.restore();
    }
}
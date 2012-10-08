var Piece = (function () {
    function Piece(player, type) {
        this._player = player;
        this._type = type;
        this._square = null;
        this._selected = false;
    }
    Piece.WhiteColor = "#FFFFFF";
    Piece.BlackColor = "#000000";
    Piece.prototype.getPlayer = function () {
        return this._player;
    };
    Piece.prototype.getType = function () {
        return this._type;
    };
    Piece.prototype.getSquare = function () {
        return this._square;
    };
    Piece.prototype.setSquare = function (square) {
        if(this._square != null) {
            this._square.setPiece(null);
        }
        this._square = square;
        if(square != null) {
            square.setPiece(this);
        }
    };
    Piece.prototype.getPosition = function () {
        return this._square.getId();
    };
    Piece.prototype.getSelected = function () {
        return this._selected;
    };
    Piece.prototype.setSelected = function (val) {
        this._selected = val;
    };
    Piece.prototype.draw = function (ctx, x, y) {
        switch(this._type) {
            case "K": {
                Piece.drawKing(ctx, this._player, x, y);
                break;

            }
            case "Q": {
                Piece.drawQueen(ctx, this._player, x, y);
                break;

            }
            case "R": {
                Piece.drawRook(ctx, this._player, x, y);
                break;

            }
            case "B": {
                Piece.drawBishop(ctx, this._player, x, y);
                break;

            }
            case "N": {
                Piece.drawKnight(ctx, this._player, x, y);
                break;

            }
            default: {
                Piece.drawPawn(ctx, this._player, x, y);
                break;

            }
        }
    };
    Piece.drawPawn = function drawPawn(ctx, player, x, y) {
        ctx.save();
        ctx.translate(x, y);
        ctx.strokeStyle = (player.getId() == 0 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.fillStyle = (player.getId() == 1 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.lineWidth = 1.5;
        ctx.lineJoin = 'miter';
        ctx.miterLimit = 4;
        ctx.beginPath();
        ctx.moveTo(22, 9);
        ctx.bezierCurveTo(19.792, 9, 18, 10.792, 18, 13);
        ctx.bezierCurveTo(18, 13.885, 18.294, 14.712, 18.781, 15.375);
        ctx.bezierCurveTo(16.829, 16.497, 15.5, 18.588, 15.5, 21);
        ctx.bezierCurveTo(15.5, 23.034, 16.442, 24.839, 17.906, 26.031);
        ctx.bezierCurveTo(14.907, 27.089, 10.5, 31.578, 10.5, 39.5);
        ctx.lineTo(33.5, 39.5);
        ctx.bezierCurveTo(33.5, 31.578, 29.093, 27.089, 26.094, 26.031);
        ctx.bezierCurveTo(27.558, 24.839, 28.5, 23.034, 28.5, 21);
        ctx.bezierCurveTo(28.5, 18.588, 27.171, 16.497, 25.219, 15.375);
        ctx.bezierCurveTo(25.706, 14.712, 26, 13.885, 26, 13);
        ctx.bezierCurveTo(26, 10.792, 24.208, 9, 22, 9);
        ctx.stroke();
        ctx.fill();
        ctx.restore();
    }
    Piece.drawKing = function drawKing(ctx, player, x, y) {
        ctx.save();
        ctx.translate(x, y);
        ctx.strokeStyle = (player.getId() == 0 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.fillStyle = (player.getId() == 1 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.lineWidth = 1.5;
        ctx.lineJoin = 'miter';
        ctx.miterLimit = 4;
        ctx.beginPath();
        ctx.moveTo(22.5, 25);
        ctx.bezierCurveTo(22.5, 25, 27, 17.5, 25.5, 14.5);
        ctx.bezierCurveTo(25.5, 14.5, 24.5, 12, 22.5, 12);
        ctx.bezierCurveTo(20.5, 12, 19.5, 14.5, 19.5, 14.5);
        ctx.bezierCurveTo(18, 17.5, 22.5, 25, 22.5, 25);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.moveTo(11.5, 37);
        ctx.bezierCurveTo(17, 40.5, 27, 40.5, 32.5, 37);
        ctx.lineTo(32.5, 30);
        ctx.bezierCurveTo(32.5, 30, 41.5, 25.5, 38.5, 19.5);
        ctx.bezierCurveTo(34.5, 13, 25, 16, 22.5, 23.5);
        ctx.lineTo(22.5, 27);
        ctx.lineTo(22.5, 23.5);
        ctx.bezierCurveTo(19, 16, 9.5, 13, 6.5, 19.5);
        ctx.bezierCurveTo(3.5, 25.5, 11.5, 29.5, 11.5, 29.5);
        ctx.lineTo(11.5, 37);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.moveTo(11.5, 29.5);
        ctx.bezierCurveTo(17, 27, 27, 27, 32.5, 30);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(11.5, 37);
        ctx.bezierCurveTo(17, 34.5, 27, 34.5, 32.5, 37);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(11.5, 33.5);
        ctx.bezierCurveTo(17, 31.5, 27, 31.5, 32.5, 33.5);
        ctx.stroke();
        ctx.strokeStyle = Piece.BlackColor;
        ctx.beginPath();
        ctx.moveTo(20, 8);
        ctx.lineTo(25, 8);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(22.5, 11.625);
        ctx.lineTo(22.5, 6);
        ctx.stroke();
        ctx.restore();
    }
    Piece.drawRook = function drawRook(ctx, player, x, y) {
        ctx.save();
        ctx.translate(x, y);
        ctx.strokeStyle = (player.getId() == 0 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.fillStyle = (player.getId() == 1 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.lineWidth = 1.5;
        ctx.miterLimit = 4;
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(9, 39);
        ctx.lineTo(36, 39);
        ctx.lineTo(36, 36);
        ctx.lineTo(9, 36);
        ctx.lineTo(9, 39);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(12, 36);
        ctx.lineTo(12, 32);
        ctx.lineTo(33, 32);
        ctx.lineTo(33, 36);
        ctx.lineTo(12, 36);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(11, 14);
        ctx.lineTo(11, 9);
        ctx.lineTo(15, 9);
        ctx.lineTo(15, 11);
        ctx.lineTo(20, 11);
        ctx.lineTo(20, 9);
        ctx.lineTo(25, 9);
        ctx.lineTo(25, 11);
        ctx.lineTo(30, 11);
        ctx.lineTo(30, 9);
        ctx.lineTo(34, 9);
        ctx.lineTo(34, 14);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(34, 14);
        ctx.lineTo(31, 17);
        ctx.lineTo(14, 17);
        ctx.lineTo(11, 14);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'miter';
        ctx.beginPath();
        ctx.moveTo(31, 17);
        ctx.lineTo(31, 29.5);
        ctx.lineTo(14, 29.5);
        ctx.lineTo(14, 17);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(31, 29.5);
        ctx.lineTo(32.5, 32);
        ctx.lineTo(12.5, 32);
        ctx.lineTo(14, 29.5);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'miter';
        ctx.lineWidth = 1;
        ctx.beginPath();
        ctx.moveTo(11, 14);
        ctx.lineTo(34, 14);
        ctx.stroke();
        ctx.restore();
    }
    Piece.drawKnight = function drawKnight(ctx, player, x, y) {
        ctx.save();
        ctx.translate(x, y);
        ctx.strokeStyle = (player.getId() == 0 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.fillStyle = (player.getId() == 1 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.lineWidth = 1.5;
        ctx.miterLimit = 4;
        ctx.lineJoin = 'miter';
        ctx.beginPath();
        ctx.moveTo(22, 10);
        ctx.bezierCurveTo(32.5, 11, 38.5, 18, 38, 39);
        ctx.lineTo(15, 39);
        ctx.bezierCurveTo(15, 30, 25, 32.5, 23, 18);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(24, 18);
        ctx.bezierCurveTo(24.384, 20.911, 18.447, 25.369, 16, 27);
        ctx.bezierCurveTo(13, 29, 13.181, 31.343, 11, 31);
        ctx.bezierCurveTo(9.9583, 30.056, 12.413, 27.962, 11, 28);
        ctx.bezierCurveTo(10, 28, 11.187, 29.232, 10, 30);
        ctx.bezierCurveTo(9, 30, 5.9968, 31, 6, 26);
        ctx.bezierCurveTo(6, 24, 12, 14, 12, 14);
        ctx.bezierCurveTo(12, 14, 13.886, 12.098, 14, 10.5);
        ctx.bezierCurveTo(13.274, 9.5056, 13.5, 8.5, 13.5, 7.5);
        ctx.bezierCurveTo(14.5, 6.5, 16.5, 10, 16.5, 10);
        ctx.lineTo(18.5, 10);
        ctx.bezierCurveTo(18.5, 10, 19.282, 8.0081, 21, 7);
        ctx.bezierCurveTo(22, 7, 22, 10, 22, 10);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(9, 23.5);
        ctx.arc(8, 23.5, 0, 0.5, 0.5, true);
        ctx.arc(9, 23.5, 0, 0.5, 0.5, true);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(15, 15.5);
        ctx.arc(14, 15.5, 0, 0.5, 1.5, true);
        ctx.arc(15, 15.5, 0, 0.5, 1.5, true);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'miter';
        ctx.beginPath();
        ctx.moveTo(37, 39);
        ctx.bezierCurveTo(38, 19, 31.5, 11.5, 25, 10.5);
        ctx.stroke();
        ctx.restore();
    }
    Piece.drawBishop = function drawBishop(ctx, player, x, y) {
        ctx.save();
        ctx.translate(x, y);
        ctx.strokeStyle = (player.getId() == 0 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.fillStyle = (player.getId() == 1 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.lineWidth = 1.5;
        ctx.miterLimit = 4;
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(9, 36);
        ctx.bezierCurveTo(12.385, 35.028, 19.115, 36.431, 22.5, 34);
        ctx.bezierCurveTo(25.885, 36.431, 32.615, 35.028, 36, 36);
        ctx.bezierCurveTo(36, 36, 37.646, 36.542, 39, 38);
        ctx.bezierCurveTo(38.323, 38.972, 37.354, 38.986, 36, 38.5);
        ctx.bezierCurveTo(32.615, 37.528, 25.885, 38.958, 22.5, 37.5);
        ctx.bezierCurveTo(19.115, 38.958, 12.385, 37.528, 9, 38.5);
        ctx.bezierCurveTo(7.6459, 38.986, 6.6771, 38.972, 6, 38);
        ctx.bezierCurveTo(7.3541, 36.055, 9, 36, 9, 36);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.moveTo(15, 32);
        ctx.bezierCurveTo(17.5, 34.5, 27.5, 34.5, 30, 32);
        ctx.bezierCurveTo(30.5, 30.5, 30, 30, 30, 30);
        ctx.bezierCurveTo(30, 27.5, 27.5, 26, 27.5, 26);
        ctx.bezierCurveTo(33, 24.5, 33.5, 14.5, 22.5, 10.5);
        ctx.bezierCurveTo(11.5, 14.5, 12, 24.5, 17.5, 26);
        ctx.bezierCurveTo(17.5, 26, 15, 27.5, 15, 30);
        ctx.bezierCurveTo(15, 30, 14.5, 30.5, 15, 32);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.arc(22.5, 8, 2.5, 0, 2 * Math.PI, true);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'miter';
        ctx.beginPath();
        ctx.moveTo(22.5, 15.5);
        ctx.lineTo(22.5, 20.5);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(20, 18);
        ctx.lineTo(25, 18);
        ctx.stroke();
        ctx.lineWidth = 1;
        ctx.beginPath();
        ctx.moveTo(17, 26);
        ctx.lineTo(28, 26);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(15, 30);
        ctx.lineTo(30, 30);
        ctx.stroke();
        ctx.restore();
    }
    Piece.drawQueen = function drawQueen(ctx, player, x, y) {
        ctx.save();
        ctx.translate(x, y);
        ctx.strokeStyle = (player.getId() == 0 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.fillStyle = (player.getId() == 1 ? Piece.BlackColor : Piece.WhiteColor);
        ctx.lineWidth = 1.5;
        ctx.miterLimit = 4;
        ctx.beginPath();
        ctx.arc(6, 11.5, 2, 0, 2 * Math.PI, true);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.arc(13.5, 8, 2, 0, 2 * Math.PI, true);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.arc(22.5, 7, 2, 0, 2 * Math.PI, true);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.arc(31.5, 8, 2, 0, 2 * Math.PI, true);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.arc(39, 11.5, 2, 0, 2 * Math.PI, true);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.beginPath();
        ctx.moveTo(9, 26);
        ctx.bezierCurveTo(17.5, 24.5, 30, 24.5, 36, 26);
        ctx.lineTo(38, 14);
        ctx.lineTo(31, 25);
        ctx.lineTo(31, 11);
        ctx.lineTo(25.5, 24.5);
        ctx.lineTo(22.5, 9.5);
        ctx.lineTo(19.5, 24.5);
        ctx.lineTo(14, 10.5);
        ctx.lineTo(14, 25);
        ctx.lineTo(7, 14);
        ctx.lineTo(9, 26);
        ctx.stroke();
        ctx.fill();
        ctx.beginPath();
        ctx.moveTo(9, 26);
        ctx.bezierCurveTo(9, 28, 10.5, 28, 11.5, 30);
        ctx.bezierCurveTo(12.5, 31.5, 12.5, 31, 12, 33.5);
        ctx.bezierCurveTo(10.5, 34.5, 10.5, 36, 10.5, 36);
        ctx.bezierCurveTo(9, 37.5, 11, 38.5, 11, 38.5);
        ctx.bezierCurveTo(17.5, 39.5, 27.5, 39.5, 34, 38.5);
        ctx.bezierCurveTo(34, 38.5, 35.5, 37.5, 34, 36);
        ctx.bezierCurveTo(34, 36, 34.5, 34.5, 33, 33.5);
        ctx.bezierCurveTo(32.5, 31, 32.5, 31.5, 33.5, 30);
        ctx.bezierCurveTo(34.5, 28, 36, 28, 36, 26);
        ctx.bezierCurveTo(27.5, 24.5, 17.5, 24.5, 9, 26);
        ctx.stroke();
        ctx.fill();
        ctx.lineJoin = 'round';
        ctx.lineWidth = 1;
        ctx.beginPath();
        ctx.moveTo(11.5, 30);
        ctx.bezierCurveTo(15, 29, 30, 29, 33.5, 30);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(12, 33.5);
        ctx.bezierCurveTo(18, 32.5, 27, 32.5, 33, 33.5);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(10.5, 36);
        ctx.bezierCurveTo(15.5, 35, 29, 35, 34, 36);
        ctx.stroke();
        ctx.restore();
    }
    return Piece;
})();

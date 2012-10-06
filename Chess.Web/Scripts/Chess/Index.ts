///<reference path='../jquery.d.ts' />
///<reference path='Game.ts' />
///<reference path='Board.ts' />

var board : Board = null;
var game : Game = null;
var canvas: HTMLCanvasElement;

function start(userId) {
    // check for canvas, show an "Upgrade your browser" screen if they don't have it.
    var canvas = <HTMLCanvasElement>document.getElementById('board');

    if (!!canvas.getContext && !!canvas.getContext("2d")) {
        board = new Board(canvas);
        game = new Game(board);

        game.startNewGame();
        board.draw();
    }
    else {
        $("#game").toggle();
        $("#notSupported").toggle();
    }
}

$(function () {
    start(null);

    $("#board").click(e => {
        var x =  (e.pageX - $(e.srcElement).position().left); // offsetX
        var y = (e.pageY - $(e.srcElement).position().top); // offsetY
        game.action(x, y);
    });

    $("#cmdReset").click(e => {
        if (confirm('Are you sure?')) {
            start(null);
            alert('Reset!');
        }
    });

    $("#cmdMove").click(e => {
        var move : string = $("#txtMove").val();
        game.moveById(move);
    });

});

$(window).resize(() => {
    if (board != null)
        board.draw();
});

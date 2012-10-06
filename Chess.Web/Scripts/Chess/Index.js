var board = null;
var game = null;
var canvas;
function start(userId) {
    var canvas = document.getElementById('board');
    if(!!canvas.getContext && !!canvas.getContext("2d")) {
        board = new Board(canvas);
        game = new Game(board);
        game.startNewGame();
        board.draw();
    } else {
        $("#game").toggle();
        $("#notSupported").toggle();
    }
}
$(function () {
    start(null);
    $("#board").click(function (e) {
        var x = (e.pageX - $(e.srcElement).position().left);
        var y = (e.pageY - $(e.srcElement).position().top);
        game.action(x, y);
    });
    $("#cmdReset").click(function (e) {
        if(confirm('Are you sure?')) {
            start(null);
            alert('Reset!');
        }
    });
    $("#cmdMove").click(function (e) {
        var move = $("#txtMove").val();
        game.moveById(move);
    });
});
$(window).resize(function () {
    if(board != null) {
        board.draw();
    }
});

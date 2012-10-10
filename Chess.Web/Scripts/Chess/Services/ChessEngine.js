var Services;
(function (Services) {
    var ChessEngine = (function () {
        function ChessEngine() { }
        ChessEngine.move = function move(request, callback, errorCallback) {
            var settings = {
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(request),
                dataType: "json",
                success: function (resp, textStatus, jqXHR) {
                    return callback(resp);
                },
                error: function (jqXHR, textStatus, errorThrow) {
                    return errorCallback(textStatus);
                }
            };
            $.ajax("/Services/ChessEngine.svc/Move", settings);
        }
        return ChessEngine;
    })();
    Services.ChessEngine = ChessEngine;    
})(Services || (Services = {}));


var Services;
(function (Services) {
    var ChessEngine = (function () {
        function ChessEngine() { }
        ChessEngine.isValidMode = function isValidMode(request, callback, errorCallback) {
            var settings = {
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(request),
                dataType: "json",
                success: function (data, textStatus, jqXHR) {
                    return callback(data);
                },
                error: function (jqXHR, textStatus, errorThrow) {
                    return errorCallback(textStatus);
                }
            };
            $.ajax("/Services/ChessEngine.svc/IsValidMove", settings);
        }
        return ChessEngine;
    })();
    Services.ChessEngine = ChessEngine;    
})(Services || (Services = {}));


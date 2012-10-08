///<reference path='../../jquery.d.ts' />

module Services {
    export class ChessEngine {
        static isValidMode(request : IMoveRequest, callback : (isValid: bool) => void, errorCallback : (status: string) => void) : void {
            var settings: JQueryAjaxSettings = {
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(request),
                dataType: "json",
                success: (data, textStatus, jqXHR) => callback(<bool>data),
                error: (jqXHR, textStatus, errorThrow) => errorCallback(textStatus);
            }

            $.ajax("/Services/ChessEngine.svc/IsValidMove", settings);
        }
    }
    export interface IMoveRequest {
        WhitePieces: string[];
        BlackPieces: string[];
        From: string;
        To: string;
    }
}
///<reference path='../../jquery.d.ts' />

module Services {
    export class ChessEngine {
        static move(request : IMoveRequest, callback : (isValid: IMoveResponse) => void, errorCallback : (status: string) => void) : void {
            var settings: JQueryAjaxSettings = {
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(request),
                dataType: "json",
                success: (resp, textStatus, jqXHR) => callback(<IMoveResponse>resp),
                error: (jqXHR, textStatus, errorThrow) => errorCallback(textStatus);
            }

            $.ajax("/Services/ChessEngine.svc/Move", settings);
        }
    }
    export interface IMoveRequest {
        Board: {
            WhitePieces: string[];
            BlackPieces: string[];
        };
        From: string;
        To: string;
    }
    export interface IMoveResponse {
        IsValid: bool;
        IsCapture: bool;
        EnPassantSquare: string;
    }
}
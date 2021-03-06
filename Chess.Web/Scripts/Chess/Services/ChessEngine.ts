///<reference path='../../typings/jquery/jquery.d.ts' />

module Services {
    export class ChessEngine {
        static move(request: IMoveRequest, callback: (isValid: IMoveResponse) => void , errorCallback: (status: string) => void ): void {
            var settings: JQueryAjaxSettings = {
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(request),
                dataType: "json",
                success: (resp, textStatus, jqXHR) => callback(<IMoveResponse>resp),
                error: (jqXHR, textStatus, errorThrow) => errorCallback(textStatus)
            }

            $.ajax("/Services/ChessEngine.svc/Move", settings);
        }
    }
    export interface IMoveRequest {
        Board: {
            WhitePieces: string[];
            BlackPieces: string[];
            EnPassantSquare: string;
        };
        PlayerColor: number;
        From: string;
        To: string;
    } 
    export interface IMoveResponse {
        IsValid: boolean;
        IsCapture: boolean;
        EnPassantSquare: string;
        CapturedPieceSquare: string;
        IsPromotion: boolean;
    }
}
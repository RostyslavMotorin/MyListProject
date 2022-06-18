import { Data } from "@angular/router";
import { Tag } from "./TagDto";

export interface Game{
    GameID :string;
    Name: string;
    Description: string;
    PictureURL:string;
    Tags: Tag[];
    UserScore: number;
    GlobalScore: number;
    UserStatus: string;
    GlobalStatus: string;
    GameStudio : string;
    RelizeData: Data;
    ApplicationUserId:string;
}
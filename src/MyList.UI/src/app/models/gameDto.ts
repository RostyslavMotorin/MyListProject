import { Tag } from "./TagDto";

export interface Game{
    Name: string;
    Description: string;
    Tags: Tag[];
    Picture: any;
    GameStudio : string;
}
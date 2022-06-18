import { Tag } from "./TagDto";

export interface GameDto{
    Name: string;
    Description: string;
    Tags: Tag[];
    Picture: any;
    GameStudio : string;
}
import { Tag } from "./TagDto";

export interface Game{
    Name: string;
    Description: string;
    Tag: Tag[];
    GameStudio : string;
}
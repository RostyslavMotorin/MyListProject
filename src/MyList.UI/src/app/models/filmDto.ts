import { Tag } from "./TagDto";

export interface FilmDto{
    Name: string;
    Description: string;
    Tags: Tag[];
    Picture: any;
}
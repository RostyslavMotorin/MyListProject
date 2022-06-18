import { Tag } from "./TagDto";

export interface AnimeDto{
    Name: string;
    Description: string;
    Tags: Tag[];
    Picture: any;
    GlobalScore: number;
}
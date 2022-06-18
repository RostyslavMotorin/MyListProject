import { Tag } from "./TagDto";

export interface SerialDto{
    Name: string;
    Description: string;
    Tags: Tag[];
    Picture: any;
    GlobalScore: number;
}
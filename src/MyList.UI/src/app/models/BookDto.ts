import { Tag } from "./TagDto";

export interface BookDto{
    Name: string;
    Description: string;
    Tags: Tag[];
    Picture: any;
    BookSeries: string;
    GlobalScore: number;
}
import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/itemDto';
import { BookService } from 'src/app/_services/book.service';
import { ItemService } from 'src/app/_services/item.service';

@Component({
  selector: 'app-main-book',
  templateUrl: './main-book.component.html',
  styleUrls: ['./main-book.component.scss']
})
export class MainBookComponent implements OnInit {

  public endpoint: string = "BookCollection/";
  items: Item[] = [];
  public search: string = "";
  public path: string = "book/soloBook";
  searchIvent: boolean = false;


  constructor(private bookService: BookService, private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getAll(this.endpoint).subscribe(response => {
      this.items = response;
      console.log(this.items);
    });
  }

  searchMerhod() {
    this.bookService.search(this.search).subscribe(response => {
      this.searchIvent = true;
      this.items = [];
      response.forEach(element => {
        if (element.pictureURL == "") {
          this.items.push({ id: element.gameID, name: element.name, pictureURL: 'Resources/Images/nonAviableImage.png', rating: element.globalScore })
        } 
        else {
          this.items.push({ id: element.gameID, name: element.name, pictureURL: element.pictureURL, rating: element.globalScore })
        }
      });
      console.log(this.items);
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/itemDto';
import { FilmService } from 'src/app/_services/film.service';
import { ItemService } from 'src/app/_services/item.service';

@Component({
  selector: 'app-main-film',
  templateUrl: './main-film.component.html',
  styleUrls: ['./main-film.component.scss']
})
export class MainFilmComponent implements OnInit {

  public endpoint: string = "FilmCollection/";
  items: Item[] = [];
  public search: string = "";
  public path: string = "film/soloFilm";
  searchIvent: boolean = false;


  constructor(private filmService: FilmService, private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getAll(this.endpoint).subscribe(response => {
      this.items = response;
      console.log(this.items);
    });
  }

  searchMerhod() {
    this.filmService.search(this.search).subscribe(response => {
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

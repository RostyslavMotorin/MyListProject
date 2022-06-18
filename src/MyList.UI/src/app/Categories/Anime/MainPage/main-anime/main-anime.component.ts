import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/itemDto';
import { AnimeService } from 'src/app/_services/anime.service';
import { ItemService } from 'src/app/_services/item.service';

@Component({
  selector: 'app-main-anime',
  templateUrl: './main-anime.component.html',
  styleUrls: ['./main-anime.component.scss']
})
export class MainAnimeComponent implements OnInit {

  public endpoint: string = "AnimeCollection/";
  items: Item[] = [];
  public search: string = "";
  public path: string = "anime/soloAnime";
  searchIvent: boolean = false;


  constructor(private animeService: AnimeService, private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getAll(this.endpoint).subscribe(response => {
      this.items = response;
      console.log(this.items);
    });
  }

  searchMerhod() {
    this.animeService.search(this.search).subscribe(response => {
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

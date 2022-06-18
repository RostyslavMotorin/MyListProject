import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/itemDto';
import { GameService } from 'src/app/_services/game.service';
import { ItemService } from 'src/app/_services/item.service';


@Component({
  selector: 'app-main-game',
  templateUrl: './main-game.component.html',
  styleUrls: ['./main-game.component.scss']
})
export class MainGameComponent implements OnInit {

  public endpoint: string = "GameCollection/";
  items: Item[] = [];
  public search: string = "";
  public path: string = "game/soloGame";
  searchIvent: boolean = false;


  constructor(private gameService: GameService, private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getAll(this.endpoint).subscribe(response => {
      this.items = response;
      console.log(this.items);
    });
  }

  searchMerhod() {
    this.gameService.search(this.search).subscribe(response => {
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

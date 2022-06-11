import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/itemDto';
import { GameService } from 'src/app/_services/game.service';


@Component({
  selector: 'app-main-game',
  templateUrl: './main-game.component.html',
  styleUrls: ['./main-game.component.scss']
})
export class MainGameComponent implements OnInit {

  items: Item[] | undefined;
  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    let test = this.gameService.getAllGames();
    console.log(test);
    // this.items = this.gameService.getAllGames();
  }

}

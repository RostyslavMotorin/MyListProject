import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/models/gameDto';
import { GameService } from 'src/app/_services/game.service';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.scss']
})
export class CreateGameComponent implements OnInit {
   model: Game | undefined;

  constructor(private gameServivce: GameService) {
   }

  ngOnInit(): void {
  }

  create() {
    this.gameServivce.createGame(this.model!);
  }


}

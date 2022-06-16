import { Component, OnInit } from '@angular/core';
import { CollectionDto } from 'src/app/models/CollectionDto';
import { GameService } from 'src/app/_services/game.service';

@Component({
  selector: 'app-solo-game',
  templateUrl: './solo-game.component.html',
  styleUrls: ['./solo-game.component.scss']
})
export class SoloGameComponent implements OnInit {
  id: string;
  item: any = {};

  constructor(private gameService: GameService) {

  }

  ngOnInit(): void {
    this.id = localStorage.getItem("itemId");

    this.gameService.get(this.id).subscribe(response => {
      this.item = response;
      let tags = document.getElementById('tags');
      let tagsContainer = document.createElement('div');
      tagsContainer.innerHTML = "Tags: ";
      this.item.tags.forEach(tag => {
        tagsContainer.innerHTML += tag.name + " ";
      });
      tags.appendChild(tagsContainer);
    });
  }

  addToList(status : string){
     const collection : CollectionDto = {Id: this.id, Status: status};
    this.gameService.addToList(collection).subscribe(response =>{
      console.log(response);
    });
  }
}

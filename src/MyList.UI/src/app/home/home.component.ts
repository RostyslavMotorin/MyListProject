import { Component, OnInit } from '@angular/core';
import { Item } from '../models/itemDto';
import { ItemService } from '../_services/item.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  gameItems : Item[] = [];
  gamePath: string = "game/soloGame";

  filmItems : Item[] = [];
  filmPath: string = "film/soloFilm";

  constructor(private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getTopGame().subscribe(response =>{
      this.gameItems=response;
      console.log(response);
    })

    this.itemService.getTopFilms().subscribe(response =>{
      this.filmItems=response;
      console.log(response);
    })

  }


}

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

  animeItems : Item[] = [];
  animePath: string = "anime/soloAnime";

  bookItems : Item[] = [];
  bookPath: string = "book/soloBook";

  serialItems : Item[] = [];
  serialPath: string = "serial/soloSerial";

  constructor(private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getTopGame().subscribe(response =>{
      this.gameItems=response;
    })

    this.itemService.getTopFilms().subscribe(response =>{
      this.filmItems=response;
    })

    this.itemService.getTopAnime().subscribe(response =>{
      this.animeItems=response;
      console.log(response);
    })

    this.itemService.getTopBooks().subscribe(response =>{
      this.bookItems=response;
      console.log(response);
    })

    this.itemService.getTopSerials().subscribe(response =>{
      this.serialItems=response;
      console.log(response);
    })
  }


}

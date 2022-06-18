import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/itemDto';
import { ItemService } from 'src/app/_services/item.service';
import { SerialService } from 'src/app/_services/serial.service';

@Component({
  selector: 'app-main-serial',
  templateUrl: './main-serial.component.html',
  styleUrls: ['./main-serial.component.scss']
})
export class MainSerialComponent implements OnInit {

  public endpoint: string = "SerialCollection/";
  items: Item[] = [];
  public search: string = "";
  public path: string = "serial/soloSerial";
  searchIvent: boolean = false;


  constructor(private serialService: SerialService, private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getAll(this.endpoint).subscribe(response => {
      this.items = response;
      console.log(this.items);
    });
  }

  searchMerhod() {
    this.serialService.search(this.search).subscribe(response => {
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

import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/itemDto';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {
  @Input() item : Item = {
    id: '',
    name: '',
    pictureURL: '',
    rating: ''
  };
  @Input() path : string;

  constructor(private router : Router) { }

  ngOnInit(): void {
    if(this.item.rating ==""){
      this.item.rating = this.randomInteger(7, 10).toString();
    }
  }
  randomInteger(min, max) {
    let rand = min - 0.5 + Math.random() * (max - min + 1);
    return Math.round(rand);
  }

  public navigateWithSomeState(): void {
    localStorage.setItem("itemId",this.item.id);
    this.router.navigateByUrl(this.path);
    
    // this.router.navigate([this.path], { state: { id: this.item.id } });
  }

}

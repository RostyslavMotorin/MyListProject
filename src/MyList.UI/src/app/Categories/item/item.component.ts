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
    image: '',
    rating: ''
  };
  @Input() path : string;

  constructor(private router : Router) { }

  ngOnInit(): void {
  }
  
  public navigateWithSomeState(): void {
    localStorage.setItem("itemId",this.item.id);
    this.router.navigateByUrl(this.path);
    
    // this.router.navigate([this.path], { state: { id: this.item.id } });
  }

}

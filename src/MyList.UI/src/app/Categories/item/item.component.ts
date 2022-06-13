import { Component, Input, OnInit } from '@angular/core';
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

  constructor() { }

  ngOnInit(): void {
  }

}

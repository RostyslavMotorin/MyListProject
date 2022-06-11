import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-solo-game',
  templateUrl: './solo-game.component.html',
  styleUrls: ['./solo-game.component.scss']
})
export class SoloGameComponent implements OnInit {

  id: number;
    constructor(private activateRoute: ActivatedRoute){
         
        this.id = activateRoute.snapshot.params['id'];
    }

  ngOnInit(): void {
  }

}

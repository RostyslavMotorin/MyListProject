import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/models/gameDto';
import { GameService } from 'src/app/_services/game.service';
import { Tag } from 'src/app/models/TagDto';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.scss']
})
export class CreateGameComponent implements OnInit {
  model: Partial<Game>;
  file : any;
  public response :any =  {dbPath:''};

  constructor(private gameServivce: GameService,private router : Router) {
    this.model={};
  }
  dropdownList: Array<Tag> = [];
  selectedItems: Array<Tag> = [];
  dropdownSettings = {};

  ngOnInit() {
    this.gameServivce.getAllTags().subscribe(response =>{ let array = response as Array<Tag>; this.dropdownList= array; console.log(array)});

    this.selectedItems = [ //default
    ];

    this.dropdownSettings = {
      singleSelection: false,
      idField: 'tagID',
      textField: 'name',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 5,
      allowSearchFilter: true
    };
  }
  
  create() {
    this.model.Tags = this.selectedItems;
    this.model.Picture = this.response.dbPath;
    this.gameServivce.create(this.model as Game).subscribe(response => {
    this.router.navigateByUrl('game/mainGame');
    }, error => {
      console.log(error)
    } );
  }

  onFileChanged(event : any) {
    this.file = event.target.files[0]
  }
  
  public uploadFinished = (event : any)=>{
    this.response = event;
  }

}

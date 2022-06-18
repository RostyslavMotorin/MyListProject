import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AnimeDto } from 'src/app/models/AnimeDto';
import { Tag } from 'src/app/models/TagDto';
import { AnimeService } from 'src/app/_services/anime.service';

@Component({
  selector: 'app-create-anime',
  templateUrl: './create-anime.component.html',
  styleUrls: ['./create-anime.component.scss']
})
export class CreateAnimeComponent implements OnInit {

  model: Partial<AnimeDto>;
  file : any;
  public response :any =  {dbPath:''};

  constructor(private animeServivce: AnimeService,private router : Router) {
    this.model={};
  }
  dropdownList: Array<Tag> = [];
  selectedItems: Array<Tag> = [];
  dropdownSettings = {};

  ngOnInit() {
    this.animeServivce.getAllTags().subscribe(response =>{ let array = response as Array<Tag>; this.dropdownList= array; console.log(array)});

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
    this.animeServivce.create(this.model as AnimeDto).subscribe(response => {
    this.router.navigateByUrl('anime/mainAnime');
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

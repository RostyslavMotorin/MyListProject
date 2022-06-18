import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tag } from 'src/app/models/TagDto';
import { FilmService } from 'src/app/_services/film.service';
import { FilmDto } from 'src/app/models/filmDto';
@Component({
  selector: 'app-create-film',
  templateUrl: './create-film.component.html',
  styleUrls: ['./create-film.component.scss']
})
export class CreateFilmComponent implements OnInit {

  model: Partial<FilmDto>;
  file : any;
  public response :any =  {dbPath:''};

  constructor(private filmServivce: FilmService,private router : Router) {
    this.model={};
  }
  dropdownList: Array<Tag> = [];
  selectedItems: Array<Tag> = [];
  dropdownSettings = {};

  ngOnInit() {
    this.filmServivce.getAllTags().subscribe(response =>{ let array = response as Array<Tag>; this.dropdownList= array; console.log(array)});

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
    this.filmServivce.create(this.model as FilmDto).subscribe(response => {
    this.router.navigateByUrl('film/mainFilm');
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

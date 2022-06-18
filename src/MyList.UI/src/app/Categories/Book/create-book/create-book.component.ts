import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookDto } from 'src/app/models/BookDto';
import { Tag } from 'src/app/models/TagDto';
import { BookService } from 'src/app/_services/book.service';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.scss']
})
export class CreateBookComponent implements OnInit {

  model: Partial<BookDto>;
  file : any;
  public response :any =  {dbPath:''};

  constructor(private bookServivce: BookService, private router : Router) {
    this.model={};
  }
  dropdownList: Array<Tag> = [];
  selectedItems: Array<Tag> = [];
  dropdownSettings = {};

  ngOnInit() {
    this.bookServivce.getAllTags().subscribe(response =>{ let array = response as Array<Tag>; this.dropdownList= array; console.log(array)});

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
    this.bookServivce.create(this.model as BookDto).subscribe(response => {
    this.router.navigateByUrl('book/mainBook');
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

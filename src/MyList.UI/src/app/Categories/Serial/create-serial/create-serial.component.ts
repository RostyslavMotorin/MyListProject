import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SerialDto } from 'src/app/models/SerialDto';
import { Tag } from 'src/app/models/TagDto';
import { SerialService } from 'src/app/_services/serial.service';

@Component({
  selector: 'app-create-serial',
  templateUrl: './create-serial.component.html',
  styleUrls: ['./create-serial.component.scss']
})
export class CreateSerialComponent implements OnInit {

  model: Partial<SerialDto>;
  file : any;
  public response :any =  {dbPath:''};

  constructor(private serialServivce: SerialService,private router : Router) {
    this.model={};
  }
  dropdownList: Array<Tag> = [];
  selectedItems: Array<Tag> = [];
  dropdownSettings = {};

  ngOnInit() {
    this.serialServivce.getAllTags().subscribe(response =>{ let array = response as Array<Tag>; this.dropdownList= array; console.log(array)});

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
    this.serialServivce.create(this.model as SerialDto).subscribe(response => {
    this.router.navigateByUrl('serial/mainSerial');
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

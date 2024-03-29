import { Component, OnInit } from '@angular/core';
import { CollectionDto } from 'src/app/models/CollectionDto';
import { ParamsModel } from 'src/app/_models/params.model';
import { AnimeService } from 'src/app/_services/anime.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-solo-anime',
  templateUrl: './solo-anime.component.html',
  styleUrls: ['./solo-anime.component.scss']
})
export class SoloAnimeComponent implements OnInit {

  id: string;
  item: any = {};
  user : any = {};
  isUser: boolean = false;
  status: string = "";
  editMode : boolean = false;

  isImage : boolean = false;
  constructor(private animeService: AnimeService, userService : UserService, private paramServ: ParamsModel) {
    this.user = userService.getTokenPayload();
    console.log(this.user);
  }

  ngOnInit(): void {
    this.id = localStorage.getItem("itemId");

    this.animeService.get(this.id).subscribe(response => {
      this.item = response;
      
      if(this.item.applicationUserId == this.user.nameid){
        this.isUser = true;
      }
      
      if(this.item.globalScore == null){
        this.item.globalScore = this.paramServ.randomInteger(6,10).toString();
      }

      this.status = this.item.userStatus;
      let tags = document.getElementById('tags');
      let tagsContainer = document.createElement('div');
      tagsContainer.innerHTML = "Tags: ";
      this.item.tags.forEach(tag => {
        tagsContainer.innerHTML += tag.name + " ";
      });
      tags.appendChild(tagsContainer);

      if(this.item.pictureURL.includes("http")){
        this.isImage = true;
      }
      
      if(this.status == null){
        this.status = "Status"
      }
    });

  }

  addToList(status : string){
     const collection : CollectionDto = {Id: this.id, Status: status};
    this.animeService.addToList(collection).subscribe(response =>{
      window.location.reload();
    });
  }

  changeMode(){
    this.editMode = !this.editMode; 
  }

  saveChange(){
    this.item.tags = [];
    this.animeService.Update(this.item).subscribe(resp =>{
      window.location.reload(); 
    });
  }

}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ParamsModel } from '../_models/params.model';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  isActiveCollection : boolean = false;
  selectedCollection: string = "";
  selectedSubCollection: string = "";
  typeCollection: string = "";
  user: any = {};

  gamePath :string = "game/soloGame";
  animePath :string = "anime/soloAnime";
  serialPath :string = "serial/soloSerial";
  filmPath :string = "film/soloFilm";
  bookPath :string = "book/soloBook";

  constructor(private userService: UserService,private paramModule: ParamsModel, private router: Router) { }

  ngOnInit(): void {
    
    this.userService.getUser().subscribe(response => {
      this.user =  response;
      console.log(this.user);
    });

  }

  selectCollection(collection : string){
    this.isActiveCollection = true;
    this.selectedCollection = collection;
  }

  selectSubSection(subCollection : string){
    this.selectedSubCollection = subCollection;
  }

  selectItem(id :any, path: string){
    localStorage.setItem("itemId", id);
    this.router.navigateByUrl(path);
  }

}

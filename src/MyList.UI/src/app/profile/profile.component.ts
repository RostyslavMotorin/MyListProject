import { Component, OnInit } from '@angular/core';
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
  typeCollection: string = "";
  user: any = {};

  constructor(private userService: UserService,private paramModule: ParamsModel) { }

  ngOnInit(): void {
    
    this.userService.getUser().subscribe(response => {
      this.user =  response;
      console.log(this.user);
    });

  }
  selectCollection(typeOfCollection : string){
    this.isActiveCollection = true;
    this.selectedCollection = typeOfCollection;
  }

}

import { Component, OnInit } from '@angular/core';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  users : any;
  editMode = false;
  currentUser : any;
  
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(){
    this.userService.getUsers().subscribe(response =>{
      this.users = response;
    }, error => {
      console.log(error);
    });
  }

  deleteButton(id: any){
    this.userService.deleteUser(id).subscribe(response =>{
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
  
  editButton(user : any){
    this.currentUser= user;
    this.editMode = true;
  }

  cancelEditMode(event : boolean){
    this.editMode = event;
  }
}
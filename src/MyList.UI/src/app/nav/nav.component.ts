import { Component, OnInit } from '@angular/core';
import { HomeComponent } from '../home/home.component';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
   registerMode : boolean | undefined;
   loggedIn: boolean | undefined;
  
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  login() {
    this.loggedIn = true;
    console.log(this.loggedIn)
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
  }
  
  register(){
    this.registerMode = true;
  }
}

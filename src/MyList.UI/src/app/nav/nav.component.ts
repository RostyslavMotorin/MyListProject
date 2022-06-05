import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  loggedIn: boolean | undefined;
  constructor(private accountService: AccountService) { }

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

  getCurrentUser() {
    this.accountService.currentUser$.subscribe(user => {
      this.loggedIn = !!user;
    }, error => { console.log(error) })
  }
}

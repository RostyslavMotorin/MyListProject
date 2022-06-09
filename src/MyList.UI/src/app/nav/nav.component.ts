import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  logout() {
    this.accountService.logout();
  }
}

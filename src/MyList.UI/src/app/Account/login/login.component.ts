import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  model: any = {};
  errors = {};

  constructor(private accountService: AccountService, private router : Router) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('home');
    }, error => {
      console.log(error),
      console.log(error.error.errors),
        this.errors = error.error.errors;
    } );
  }
}

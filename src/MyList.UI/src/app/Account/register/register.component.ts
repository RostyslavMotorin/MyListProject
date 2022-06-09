import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  errors = {};

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.model).subscribe(response => {
      this.router.navigateByUrl('home');
    }, error => {
      console.log(error),
      console.log(error.error.errors),
      this.errors = error.error.errors;
      this.model = {};
    });
  }
}

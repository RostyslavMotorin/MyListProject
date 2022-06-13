import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router, RoutesRecognized } from '@angular/router';
import { filter } from 'rxjs';
import { User } from './models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'MyListApp';
  users: any;

  myImage: string = "assets/background.jpg";

  constructor(private accountService: AccountService, private router: Router) {
    
   }
   
  ngOnInit() {
    this.setCurrentUser();
    var path = localStorage.getItem('lastAccessedPath'); 
    
    this.router.events
      .pipe(filter((e: any) => e instanceof RoutesRecognized)
      ).subscribe((e: any) => {
    
        if( e && e[0] && e[0].urlAfterRedirects && path){
      this.router.navigateByUrl(path);
    }});

    this.router.events.subscribe(event =>{
      if (event instanceof NavigationStart){
         localStorage.setItem('lastAccessedPath', event.url);
      }
   })
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user')!);
    this.accountService.setCurrentUser(user);
  }
}


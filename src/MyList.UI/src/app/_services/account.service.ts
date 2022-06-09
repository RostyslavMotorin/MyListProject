import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'http://localhost:5222/api/';
  private currentUSerSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUSerSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post(this.baseUrl + 'Account/login', model).pipe(
      map((response : User | any) => {
        const user = response
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUSerSource.next(user);
        }
      })
    );
  }

  register(model: any){
    console.log(model);
    return this.http.post(this.baseUrl + 'Account/Register', model).pipe(
      map((response : User | any) => {
        const user = response
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUSerSource.next(user);
        }
      })
    );
  }

  setCurrentUser(user : User){
    this.currentUSerSource.next(user);
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUSerSource.next(null);

  }
}

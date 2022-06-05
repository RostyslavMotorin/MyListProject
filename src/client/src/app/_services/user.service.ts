import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = "http://localhost:5000/api/";
  users: any;
  token: string | undefined;
  actualUser!: User;
  headers = new HttpHeaders;

  constructor(private http: HttpClient) {
    this.getUsers();
  }

  getUsers() {
    const headers = this.createHeader();
    return this.http.get(this.baseUrl + "Users/GetUsers", { headers });
  }

  getUser(id: any) {
    const headers = this.createHeader();
    return this.http.get(this.baseUrl + "Users/GetUser?id=" + id, { headers });
  }

  editUser(dtoUser: any) {
    var user: User = JSON.parse(localStorage.getItem("user")!!);
    this.token = "Bearer ";
    this.token += user.token;

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    myHeaders.append("Authorization", this.token);
    
    var requestOptions:RequestInit = {
      method: 'POST',
      headers: myHeaders,
      body: JSON.stringify(dtoUser),
      redirect: 'follow'
    };
    
    fetch("http://localhost:5000/api/Users/EditUser", requestOptions )
      .then(response => response.text())
      .then(result => console.log(result))
      .catch(error => console.log('error', error));
  }

  changeRole() {
    const headers = this.createHeader();
    return this.http.get(this.baseUrl + "Roles/EditRole", { headers });
  }

  getRoles() {
    const headers = this.createHeader();
    return this.http.get(this.baseUrl + "Roles/GetRoles", { headers });
  }

  deleteUser(id: any) {
    const headers = this.createHeader();
    return this.http.delete(this.baseUrl + "Users/DeleteUser?id=" + id, { headers });
  }

  createHeader() {
    var user: User = JSON.parse(localStorage.getItem("user")!!);
    this.token = "Bearer ";
    this.token += user.token;

    const headers = new HttpHeaders(
      { Authorization: this.token! }
    );
    return headers;
  }
}

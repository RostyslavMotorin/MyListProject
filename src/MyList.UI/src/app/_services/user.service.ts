import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ParamsModel } from '../_models/params.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl: string | undefined;
  private endpoint = "User/";
  
  constructor(private http: HttpClient, private paramsModel: ParamsModel) {
    this.baseUrl = paramsModel.getUrl();
  }

  getUser() {
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'Get', { headers });
  }
}

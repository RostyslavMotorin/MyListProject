import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TokenPayLoad } from '../models/TokenPayload';
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

  private getToken() {
    return localStorage.getItem('user');
}

public getTokenPayload(token?: string) {
    if (!token) {
        token = this.getToken();
    }
    if (token) {
        try {
            const base64 = token.split(".")[1];
            const json = atob(base64);
            const payload: TokenPayLoad = JSON.parse(json);
            return payload;
        } catch {
            return null;
        }
    }
    return null;
}
}

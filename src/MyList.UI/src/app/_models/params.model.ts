import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';

    @Injectable()

    export class ParamsModel {
        private baseUrl: string = "http://localhost:5222/api/";

        constructor() {}
        
        public getUrl() {
            return this.baseUrl;
        }

        createHeader() {
            let user: User = JSON.parse(localStorage.getItem("user")!!);
            let token = "Bearer ";
            token += user.token;
        
            const headers = new HttpHeaders(
              { Authorization: token! }
            );
            return headers;
          }

          randomInteger(min, max) {
            let rand = min - 0.5 + Math.random() * (max - min + 1);
            return Math.round(rand);
          }
    }
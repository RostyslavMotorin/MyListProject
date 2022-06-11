import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ParamsModel } from '../_models/params.model';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  baseUrl: string | undefined;

  constructor(private http: HttpClient, private paramsModel: ParamsModel) {
    this.baseUrl = paramsModel.getUrl();
  }
}

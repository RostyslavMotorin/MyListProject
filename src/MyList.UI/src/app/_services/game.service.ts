import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Game } from '../models/gameDto';
import { ParamsModel } from '../_models/params.model';


@Injectable({
  providedIn: 'root'
})
export class GameService {

  private baseUrl: string | undefined;
  private endpoint = "GameCollection";

  constructor(private http: HttpClient, private paramsModel: ParamsModel) {
    this.baseUrl = paramsModel.getUrl();
  }

  getAllGames(){
    return this.http.get(this.baseUrl + this.endpoint + 'GetAll');
  }

  createGame(model : Game){
    return this.http.post(this.baseUrl + this.endpoint + 'Create', model);
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Game } from '../models/gameDto';
import { ParamsModel } from '../_models/params.model';


@Injectable({
  providedIn: 'root'
})
export class GameService {

  private baseUrl: string | undefined;
  private endpoint = "GameCollection/";

  constructor(private http: HttpClient, private paramsModel: ParamsModel) {
    this.baseUrl = paramsModel.getUrl();
  }

  getAll() {
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'GetAll', { headers });
  }

  getAllTags() {
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'GetAllTags', { headers });
  }

  create(model: Game) {
    const headers = this.paramsModel.createHeader();
    return this.http.post(this.baseUrl + this.endpoint + 'Create', model, { headers });
  }
  get(id:string){
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'Get?id='+id, { headers });
  }

  addToList(id:string){
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'AddToList?id='+id, { headers });
  }
}

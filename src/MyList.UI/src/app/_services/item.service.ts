import { HttpClient } from '@angular/common/http';
import { Injectable, Input, Output } from '@angular/core';
import { Item } from '../models/itemDto';
import { ParamsModel } from '../_models/params.model';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  // @Output() public model: Array<Item> = [];
  private baseUrl: string;

  constructor(private http: HttpClient, private paramsModel: ParamsModel) {
    this.baseUrl = paramsModel.getUrl();
  }

  getAll(endpoint : string) {
    const headers = this.paramsModel.createHeader();
    return this.http.get<Array<Item>>(this.baseUrl + endpoint + 'GetAll', { headers });
  }

  getTopGame(){
    const headers = this.paramsModel.createHeader();
    return this.http.get<Array<Item>>(this.baseUrl + 'GameCollection/GetTop', { headers });
  }

  getTopFilms(){
    const headers = this.paramsModel.createHeader();
    return this.http.get<Array<Item>>(this.baseUrl + 'FilmCollection/GetTop', { headers });
  }

  getTopBooks(){
    const headers = this.paramsModel.createHeader();
    return this.http.get<Array<Item>>(this.baseUrl + 'BookCollection/GetTop', { headers });
  }

  getTopAnime(){
    const headers = this.paramsModel.createHeader();
    return this.http.get<Array<Item>>(this.baseUrl + 'AnimeCollection/GetTop', { headers });
  }

  getTopSerials(){
    const headers = this.paramsModel.createHeader();
    return this.http.get<Array<Item>>(this.baseUrl + 'SerialCollection/GetTop', { headers });
  }
}

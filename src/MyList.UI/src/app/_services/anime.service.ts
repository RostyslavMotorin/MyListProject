import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ParamsModel } from '../_models/params.model';

@Injectable({
  providedIn: 'root'
})
export class AnimeService {

  private baseUrl: string | undefined;
  private endpoint = "AnimeCollection/";
  
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

  create(model: any) {
    const headers = this.paramsModel.createHeader();
    return this.http.post(this.baseUrl + this.endpoint + 'Create', model, { headers });
  }
  getById(id:string){
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'Get?id='+id, { headers });
  }

  addToList(id:string){
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'AddToList?id='+id, { headers });
  }
}

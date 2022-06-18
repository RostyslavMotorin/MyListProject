import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CollectionDto } from '../models/CollectionDto';
import { ParamsModel } from '../_models/params.model';

@Injectable({
  providedIn: 'root'
})
export class FilmService {

  private baseUrl: string | undefined;
  private endpoint = "FilmCollection/";
  
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

  addToList(collection:CollectionDto){
    const headers = this.paramsModel.createHeader();
    return this.http.post(this.baseUrl + this.endpoint + 'AddToList', collection, { headers });
  }

  Update(item :any){
    const headers = this.paramsModel.createHeader();
    return this.http.post(this.baseUrl + this.endpoint + 'Update', item, { headers });
  }

  search(search :string){
    const headers = this.paramsModel.createHeader();
    return this.http.get<Array<any>>(this.baseUrl + this.endpoint + 'GetSearch?search=' + search, { headers });
  }

  get(id:string){
    const headers = this.paramsModel.createHeader();
    return this.http.get(this.baseUrl + this.endpoint + 'Get?id='+id, { headers });
  }
}

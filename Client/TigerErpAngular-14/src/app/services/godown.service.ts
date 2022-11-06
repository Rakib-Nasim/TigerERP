import { GodownModel } from './../models/GodownModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GodownService {
  baseApiUrl: string = environment.apiUrl + '/api/Godown/';
  constructor(private http: HttpClient) { }

  getGodownByCompId(compId:number){
    return this.http.get(this.baseApiUrl+'GetAllGodownByComp/'+compId);
  }

  saveGodown(godown:GodownModel) {
    return this.http.post(this.baseApiUrl+'AddGodown',godown);
  }

  getGodownById(id:number) {
    return this.http.get(this.baseApiUrl+'GetGodownById/'+id);
  }
  deleteColor(id: number) {
    return this.http.delete(this.baseApiUrl + 'DeleteGodown/'+id);
  }

}

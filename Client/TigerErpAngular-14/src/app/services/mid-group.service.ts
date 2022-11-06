import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MidGroupService {
  baseApiUrl: string = environment.apiUrl + '/api/AccountGroup/';
  constructor(private http: HttpClient) { }

  getLowerMidGroup(){
    return this.http.get(this.baseApiUrl+'GetAllGroupMid') ;
  }

  getAllCashFlow(){
    return this.http.get(this.baseApiUrl+'GetAllCashFlow') ;
  }
}

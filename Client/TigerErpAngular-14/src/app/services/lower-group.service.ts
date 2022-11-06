import { AccountGroupLower } from '../models/AccountGroupLowerModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LowerGroupService {
  baseApiUrl: string = environment.apiUrl + '/api/LowerGroup/';
  constructor(private http: HttpClient) { }

  saveLowerGroup(model:AccountGroupLower){
   return this.http.post(this.baseApiUrl+'AddLowerGroup/',model);
  }

  getAllLowerGroup(id:number){
   return this.http.get(this.baseApiUrl+'GetAllAccountGroupLowerrByComp/'+id);
  }
}

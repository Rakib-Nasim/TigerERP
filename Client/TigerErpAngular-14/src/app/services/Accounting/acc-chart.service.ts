import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccChartService {

  baseApiUrl: string = environment.apiUrl + '/api/AccChart/';
  constructor(private http: HttpClient) { }

  getAllAccChartByComp(compId:number,lowerGroup:number){
    return this.http.get(this.baseApiUrl+'getAllAccountGroup/compId/'+compId+'/lowerGroup/'+lowerGroup);
  }
}

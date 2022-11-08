import { AccChartModel } from 'src/app/models/AccChartModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccChartService {

  baseApiUrl: string = environment.apiUrl + '/api/AccChart/';
  constructor(private http: HttpClient) { }

  getAllAccChartByComp(compId:number){
    return this.http.get(this.baseApiUrl+'GetAllAccChartByComp/'+compId);
  }

  saveLedger(ledger:AccChartModel){
    console.log("Ledger entry",ledger);
    return this.http.post(this.baseApiUrl+'AddAccChart',ledger);
  }
}

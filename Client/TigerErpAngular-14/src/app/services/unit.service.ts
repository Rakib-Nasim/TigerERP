import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UnitService {
  baseApiUrl: string = environment.apiUrl +'/api/unit/';
  constructor(private http: HttpClient) { }


  saveUnit(unit: any) {
    return this.http.post(this.baseApiUrl + 'AddUnit', unit);
  }

  getAllUnitByComp(compId: number) {
    return this.http.get(this.baseApiUrl + 'GetAllUnitByComp/' + compId);
  }


  getUnitById(unitId: number) {
    return this.http.get(this.baseApiUrl + 'GetUnitById/' + unitId);
  }

  deleteUnit(id: number) {
    return this.http.delete(this.baseApiUrl + 'DeleteUnit/' + id);
  }
}

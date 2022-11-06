import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BranchService {
  baseApiUrl: string = environment.apiUrl + '/api/Branch/';
  constructor(private http: HttpClient) { }

  getBranchByCompId(compId: number) {
    return this.http.get(this.baseApiUrl + 'GetAllBranchByComp/' + compId);
  }
  
}

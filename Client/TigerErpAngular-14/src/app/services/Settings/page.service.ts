import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PageModel } from './../../models/PageModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PageService {
  baseApiUrl: string = environment.apiUrl + '/api/Page/';
  constructor(private http: HttpClient) { }

  savePage(page:PageModel){
    return this.http.post(this.baseApiUrl +'AddPage',page)
} 

getAllPage(){
  return this.http.get(this.baseApiUrl +'GetAllPage')
} 

getPageById(id:any){
  return this.http.get(this.baseApiUrl +'GetPageById/',id)
} 
}

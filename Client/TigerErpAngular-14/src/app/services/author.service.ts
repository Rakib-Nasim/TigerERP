import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  baseApiUrl: string = environment.apiUrl + '/api/color/';
  constructor(private http: HttpClient) { }


  saveAuthor(color: any) {
    return this.http.post(this.baseApiUrl + 'AddColor', color);
  }

  getAllColorByComp(compId: number) {
    return this.http.get(this.baseApiUrl + 'GetAllColorByComp/' + compId);
  }


  getColorById(colorId: number) {
    return this.http.get(this.baseApiUrl + 'GetColorById/' + colorId);
  }

  deleteColor(id: number) {
    return this.http.delete(this.baseApiUrl + 'deleteColor/' + id);
  }
}

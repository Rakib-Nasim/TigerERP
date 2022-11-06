import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookEntryService {
  baseApiUrl: string =environment.apiUrl;
  constructor(private http:HttpClient) { }

  
  getAllBook(compId:number){
    return this.http.get(this.baseApiUrl+'/api/product/GetProductByComp/'+compId);
  }
  
  saveProduct(product: any) {
    return this.http.post(this.baseApiUrl + '/api/product/AddProduct', product);
  }
  
}

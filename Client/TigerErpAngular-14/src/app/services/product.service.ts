import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseApiUrl: string =environment.apiUrl+'/api/product/';
  constructor(private http:HttpClient) { }
  
  getAllProductByComp(compId:number){
    return this.http.get(this.baseApiUrl+'GetProductByComp/'+compId);
  }

  getAllActiveProductByComp(compId:number){
    return this.http.get(this.baseApiUrl+'GetAllActiveProductByComp/'+compId);
  }
  
  saveProduct(product: any) {
    return this.http.post(this.baseApiUrl + '/api/product/AddProduct', product);
  }
  
}

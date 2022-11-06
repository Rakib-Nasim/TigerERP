import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
 baseApiUrl: string =environment.apiUrl;
  constructor(private http:HttpClient) { }

  getAllCategory(compId:number){
    return this.http.get(this.baseApiUrl+'/api/category/GetAllCategoryByComp/'+compId);
  }
  getAllProductType(compId:number){
    return this.http.get(this.baseApiUrl+'/api/category/GetAllProductTypeByComp/'+compId);
  }

  saveCategory(category:any){
    return this.http.post(this.baseApiUrl+'/api/category/AddCategory',category);
  }

  

}

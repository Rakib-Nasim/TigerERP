import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  baseApiUrl: string = environment.apiUrl + '/api/brand/';
  constructor(private http: HttpClient) { }


  savePublisher(brand: any) {
    return this.http.post(this.baseApiUrl + 'AddBrand', brand);
  }
  getBrandById(brandId: number) {
    return this.http.get(this.baseApiUrl + 'GetBrandById/' + brandId);
  }
  getAllBrandByComp(compId: number) {
    return this.http.get(this.baseApiUrl + 'GetAllBrandByComp/' + compId);
  }
  deleteBrand(id: number) {
    return this.http.delete(this.baseApiUrl + 'DeleteBrand/' + id);
  }
}

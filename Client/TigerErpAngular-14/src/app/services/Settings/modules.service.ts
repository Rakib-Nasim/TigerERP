import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ModuleModel } from './../../models/Module';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ModulesService {

  baseApiUrl: string = environment.apiUrl + '/api/module/';
  constructor(private http: HttpClient) { }
  
  saveModule(module:ModuleModel){
      return this.http.post(this.baseApiUrl +'AddModule',module)
  } 

    getAllModules() {
    return this.http.get(this.baseApiUrl + 'GetAllModule');
  }
  getModulesById(id:number){
    return this.http.get(this.baseApiUrl +'GetModuleById/'+ id)
  }

    getSubModuleWithPage(userId: number, companyId: number,logedUserId :number, moduleId = -1) {
    return this.http.get(this.baseApiUrl + `GetSubModuleWithPage/${userId}/${companyId}/${logedUserId}/${moduleId}`)
  }
}

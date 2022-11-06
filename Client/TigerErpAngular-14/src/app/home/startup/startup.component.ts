import { Component, OnInit } from '@angular/core';

import { LoaderService } from './../../services/interceptorService/loader.service';
import { ModulesModel } from 'src/app/models/ModulesModel';
import { ModulesService } from './../../services/Settings/modules.service';

@Component({
  selector: 'app-startup',
  templateUrl: './startup.component.html',
  styleUrls: ['./startup.component.css']
})
export class StartupComponent implements OnInit {
  public compId: number = 202;

  public lstModulesModel:ModulesModel[] = [];
  constructor(private _moduleService:ModulesService,
    private _loaderService:LoaderService
    ) { }

  ngOnInit(): void {
    this.getAllModules();
  }

  getAllModules() {
    this._moduleService.getAllModules().subscribe(res => {
      this.lstModulesModel = (res as ModulesModel[]).filter(m=>m.parentModuleId==0);
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ModulesModel } from 'src/app/models/ModulesModel';
import { ModulesService } from '../../../../services/Settings/modules.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-modules',
  templateUrl: './modules.component.html',
  styleUrls: ['./modules.component.css']
})
export class ModulesComponent implements OnInit {
  public moduleForm:FormGroup;
  public searchText: string;
  lstModulesModel:ModulesModel[]=[];
  lstParentModules:any[]=[];
  modulesModel:ModulesModel | undefined;
  constructor(private fb:FormBuilder,
              private _modalService:NgbModal,
              private _toasterService:ToastrService,
              private _moduleService:ModulesService) { }

  ngOnInit(): void {
    this.getAllModules();
    this.getAllParrentModule()
    this.creatForm();
  }

  getAllModules() {
    this._moduleService.getAllModules().subscribe(res => {
      this.lstModulesModel = res as ModulesModel[];
      console.log("lstModulesModel",this.lstModulesModel);
    });
  }

  
   getAllParrentModule() {
    this._moduleService.getAllModules().subscribe(res => {
      this.lstParentModules = (res as ModulesModel[]).filter(m=>m.parentModuleId==0);

    });
  }

  openModalForSave(event:any){
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
  }

  reset(){
    this.getAllModules();
    this.creatForm();
  }

  saveModule(){
     if (this.moduleForm.invalid) {
      this._toasterService.error("Please fill the all required fields", "Invalid submission");
      return;
    }
     if(this.formVal.isParent===true){
      this.formVal.isParent=1;
     }
     else{
      this.formVal.isParent=0;  
     }
      this._moduleService.saveModule(this.formVal).subscribe((res: any) => {
      if (res) {
        this._toasterService.success("Save Successfully");
        this._modalService.dismissAll();
      }
    })
    
  }


  editModulesById(id:number,event:any){
    console.log("id",id)
   this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
   this._moduleService.getModulesById(id).subscribe(res=>{
   this.modulesModel = res as ModulesModel;
   this.moduleForm.patchValue(this.modulesModel);
   })
  }
  creatForm(){
    this.moduleForm=this.fb.group({
     id:[0,[]],
     parentModuleId:[0,[Validators.required]],
     name:['',[Validators.required]],
     moduleRoutePath:['',[]],
     serialNo:[0,[]],
     isParent:[0,[]],
     isActive:[1,[]],
     image:['',[]],
    })
  }

  get formVal(){
    return this.moduleForm.value
  }
    get f(){
    return this.moduleForm.controls
  }

}

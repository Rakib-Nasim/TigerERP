import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ModuleModel } from 'src/app/models/Module';
import { ModulesService } from 'src/app/services/Settings/modules.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PageModel } from '../../../../models/PageModel';
import { PageService } from 'src/app/services/Settings/page.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-page-entry',
  templateUrl: './page-entry.component.html',
  styleUrls: ['./page-entry.component.css']
})
export class PageEntryComponent implements OnInit {
  public pageEntryForm:FormGroup;
  public lstPage:PageModel[]=new Array<PageModel>();
  public lstModel:ModuleModel[]=[];
  public pageModel:PageModel=new PageModel();
  public searchText:string;

  constructor(
   public _modalService:NgbModal,
   private _fb:FormBuilder,
   private _tosterService:ToastrService,
   private _moduleService:ModulesService,
   private _pageService:PageService,

  ) { }

  ngOnInit(): void {
  this.getAllModule();
  this.getAllPage();
  this.createFrom();
  }
  getAllModule(){
    this._moduleService.getAllModules().subscribe(res=>{
     this.lstModel=res as ModuleModel[];
    })
  }

  getAllPage(){
    this._pageService.getAllPage().subscribe((res:any)=>{
      this.lstPage=res as PageModel[];
    })

  }
  editPageById(id: number, event: any){
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
    this._pageService.getPageById(id).subscribe(res=>{
    this.pageEntryForm.patchValue(res);
    })

  }

  savePage(){
    this.pageModel=this.pageEntryForm.value;
    this._pageService.savePage(this.pageModel).subscribe((res:any)=>{
      if(res){
        this._tosterService.success("Save Successfully");
        this._modalService.dismissAll();
        this.reset();
      }
      else{
        this._tosterService.error("Not Saved");
      }
   }, er=>{
    this._tosterService.error(er.message);
   })
  }

  reset(){
    this.createFrom();
  }
  


  openModalForSave(event: any) {
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
  }

  createFrom(){
    this.pageEntryForm=this._fb.group({
      id: [0, []],
      moduleId: [,[ Validators.required]],
      name: [, [Validators.required]],
      pageRoutePath: [, [Validators.required]],
      serialNo:[,[]]
    })
  }

}

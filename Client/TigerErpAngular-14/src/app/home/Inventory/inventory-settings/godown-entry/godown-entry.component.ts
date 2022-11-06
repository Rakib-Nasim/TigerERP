import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { BranchModel } from 'src/app/models/BranchModel';
import { BranchService } from 'src/app/services/branch.service';
import { GodownModel } from 'src/app/models/GodownModel';
import { GodownService } from '../../../../services/godown.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Status } from 'src/app/common/projectEnum';
import { ToastrService } from 'ngx-toastr';
import { Utility } from 'src/app/common/utility';

@Component({
  selector: 'app-godown-entry',
  templateUrl: './godown-entry.component.html',
  styleUrls: ['./godown-entry.component.css']
})
export class GodownEntryComponent implements OnInit {
  public compId:number=202;
  public searchText:string;
  public selectedItemId:number=0;
  public godownModel:GodownModel=new GodownModel();
  public lstBranch:BranchModel[]=new Array<BranchModel>();
  public lstGodown:GodownModel[]=new Array<GodownModel>();
  public lstParentGodown:GodownModel[]=new Array<GodownModel>();
  public lstStatus:any[]=[];
  public godownEntryForm:FormGroup;
  constructor(private _fb:FormBuilder,
            private _modalService:NgbModal,
            private _branchService:BranchService,
            private _toasterService: ToastrService,
            private _godownService:GodownService,
            private _utility:Utility
    ) { }
  ngOnInit(): void {
    this.lstStatus=this._utility.enumToArray(Status);
    this.getAllGodownByCompId();
    this.createForm();
    this.getAllBranch();

  }

   getAllGodownByCompId(){
    this._godownService.getGodownByCompId(this.compId).subscribe((res:any)=>{
      if(res.status){
        this.lstGodown=res.response as GodownModel[];
        this.lstParentGodown=this.lstGodown.filter(p=>p.isParent==1);
      }
    })

  }
  getAllBranch(){
    this._branchService.getBranchByCompId(this.compId).subscribe((res:any)=>{
      if(res.status){
       this.lstBranch=res.response as BranchModel[];
    }
    })
  }

  editgodownById(id: number, event: any) {
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
    this._godownService.getGodownById(id).subscribe(res=>{
      this.godownEntryForm.patchValue(res as GodownModel);
    })

  }


  saveGodown(){
   this.godownModel=this.godownEntryForm.value;
   if(this.formVal.isParent== true){
    this.godownModel.isParent=1;
  }
  else{
    this.godownModel.isParent=0;
  }
    this._godownService.saveGodown(this.godownModel).subscribe((res:any)=>{
      if(res){
        this._toasterService.success("Save Successfully");
        this.getAllGodownByCompId();
        this.reset();
        this._modalService.dismissAll();
      }
      else{
        this._toasterService.error("Not Save");
      }
    })
  }
  removeDetailFormRow(colorId: number) {
    this._godownService.deleteColor(colorId).subscribe(res => {
      this._toasterService.success("Delete Successfully");
      this.getAllGodownByCompId();
    })
  }
  delete(index: number, modal: any) {
    this.selectedItemId = index;
    this._modalService.open(modal);
  }
 
  openModalForSave(event: any) {
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
  }
  reset() {
    this.createForm();
  }
  createForm(){
  this.godownEntryForm=this._fb.group({
    id:[0,[]],
    compId:[this.compId,[]],
    branchId:[,[]],
    parentId:[,[]],
    godownName:[,[]],
    isParent:[0,[]],
    status:[1,[]]
  })
  }
  get formVal(){
    return this.godownEntryForm.value;
  } 
  get f(){
    return this.godownEntryForm.controls;
  }

}

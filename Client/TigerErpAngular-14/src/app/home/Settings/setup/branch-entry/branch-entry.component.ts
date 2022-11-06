import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { BranchModel } from 'src/app/models/BranchModel';
import { BranchService } from 'src/app/services/branch.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-branch-entry',
  templateUrl: './branch-entry.component.html',
  styleUrls: ['./branch-entry.component.css']
})
export class BranchEntryComponent implements OnInit {

  public branchEntryFrom:FormGroup;
  public compId:number=202;
  public btnStatus : string="Save";
  public typelst:any[]=[{id:1,name:'Branch'},
                        {id:2,name:'Floor Production'}];
  public branchModel:BranchModel=new BranchModel();
  public lstOfbranch:BranchModel[]=new Array<BranchModel>();
  constructor(
    private _modalService:NgbModal, 
    private _fb:FormBuilder, 
    public _branchServices:BranchService,
    private _tosterService:ToastrService,
  ) { }

  ngOnInit(): void {
   this.create();
   this.getAllBranch();
  }
  getAllBranch(){
    this._branchServices.getBranchByCompId(this.compId).subscribe((res:any)=>{
      this.lstOfbranch=res.response;
      console.log("this.lstOfbranch",this.lstOfbranch);
    })
  }
  saveBranch(){
    this.branchModel=this.formVal;
    this._branchServices.saveBranch(this.branchModel).subscribe(res=>{
      if(res){
        this._tosterService.success("Branch Save Successfully");
        this.create();
      }
      else{
        this._tosterService.error("Branch Not Save");
        this.create();
      }
      
    })
    
  }

  openModalForSave(event:any){
    this._modalService.open(event,{size: 'lg', windowClass: 'modal-xl'});
  }

create(){
  this.branchEntryFrom=this._fb.group({
  id:[0,[]],
  compId:[this.compId,[]],
  type:[,[]],
  name:[,[]],
  shortName:[,[]],
  contactNo:[,[]],
  address:[,[]],
})
}
get f(){
  return this.branchEntryFrom.controls
}
get formVal(){
  return this.branchEntryFrom.value;
}

}

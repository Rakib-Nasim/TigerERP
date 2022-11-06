import { Component, Input, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AccountGroupLower } from 'src/app/models/AccountGroupLowerModel';
import { AccountGroupMidModel } from 'src/app/models/AccountGroupMidModel';
import { CashFlowModel } from 'src/app/models/CashFlowModel';
import { LowerGroupService } from 'src/app/services/lower-group.service';
import { MidGroupService } from 'src/app/services/mid-group.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lower-group',
  templateUrl: './lower-group.component.html',
  styleUrls: ['./lower-group.component.css']
})
export class LowerGroupComponent implements OnInit {
  public title:string='Account Group Creation';
  public compId:number=202;
  public lowerEntryForm:FormGroup;
  public lstaccountMidGroup:AccountGroupMidModel[];
  public lstcashFlowModel:CashFlowModel[];
  public accountlowerGroup:AccountGroupLower=new AccountGroupLower();
  lstCashFlow:any[]=[];
  public lstlowerGroup:AccountGroupLower[];

  constructor(
    public _modalService:NgbModal,
    private _lowerGroupService:LowerGroupService,
    private _midGroupService:MidGroupService,
    private _fb:FormBuilder,
    private _tosterServices:ToastrService,
  ) { }

  ngOnInit(): void {
    this.createForm();
    this.getLowerMidGroup();
    this.getCashFlow();
  }

  getCashFlow(){
    this._midGroupService.getAllCashFlow().subscribe(res=>{
      this.lstCashFlow=res as any[];
    })
  }
  getLowerMidGroup(){
  this._midGroupService.getLowerMidGroup().subscribe((res:any)=>{
    this.lstaccountMidGroup=res as AccountGroupMidModel[];
  })
  }

  getAllCashFlow(){
   this._midGroupService.getAllCashFlow().subscribe(res=>{
    this.lstcashFlowModel=res as CashFlowModel[];
   })
  }
  getAllLowerGroup(){
    this._lowerGroupService.getAllLowerGroup(this.compId).subscribe((res:any)=>{
      this.lstlowerGroup=res as AccountGroupLower[];
      console.log("this.lstlowerGroup",this.lstlowerGroup);
    })
  }

  saveLowerGroups(){
  this.accountlowerGroup=this.lowerEntryForm.value;
  this._lowerGroupService.saveLowerGroup(this.accountlowerGroup).subscribe(res=>{
    this._tosterServices.success("Save Successfull");
  })
  }


  openModalForSave(event: any) {
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
  }

  createForm(){
    this.lowerEntryForm=this._fb.group({
      id:[0,[]],
      compId:[this.compId,[]],
      profitLossCaption:[,[]],
      fundFlowCaption:[,[]],
      midGroupId:[,[Validators.required]],
      lowerGroupId:[0,[]],
      groupName :[,[Validators.required]],
      groupNameAlias :[,[]],
      amount :[,[]],
      accType :[,[]],
      balanceType :[,[]],
      balancesheetCaption :[,[]],
      isParent:[,[]],
      parentId:[0,[]],
      cashFlowId:[,[]],
      balNotes:[,[]],
      incomeNotes:[,[]],
      notesAccounts:[,[]],
      notesCaption:[,[]],
      cashFlowPO:[,[]],
    })
  }
  
  get f(){
    return this.lowerEntryForm.controls;
  }
  get formVal(){
    return this.lowerEntryForm.value;
  }

}

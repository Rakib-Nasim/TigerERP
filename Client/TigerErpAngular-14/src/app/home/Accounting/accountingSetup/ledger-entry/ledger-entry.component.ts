import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { AccChartModel } from 'src/app/models/AccChartModel';
import { AccChartService } from 'src/app/services/Accounting/acc-chart.service';
import { AccountGroupLower } from 'src/app/models/AccountGroupLowerModel';
import { BranchModel } from './../../../../models/BranchModel';
import { BranchService } from 'src/app/services/branch.service';
import { LowerGroupService } from 'src/app/services/lower-group.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-ledger-entry',
  templateUrl: './ledger-entry.component.html',
  styleUrls: ['./ledger-entry.component.css']
})
export class LedgerEntryComponent implements OnInit {
  public ledgerForm:FormGroup;
  public compId:number=202;
  public lstOfbranch:BranchModel[]= new Array<BranchModel>();
  public lstlowerGroup:AccountGroupLower[]=new Array<AccountGroupLower>();
  public currency:any[]=[{id:1,name:'Taka',sortName:'Tk'},
                         {id:2,name:'Dollar',sortName:'$'},
                         {id:3,name:'Euro',sortName:'€'},
                         {id:4,name:'Yen',sortName:'¥'},
                         {id:5,name:'Pound',sortName:'£'},
                        ];
  public subLeadegerList:any[]=[{id:1,name:'Independ Subledger'},
                         {id:2,name:'Dependent Subledger'}
                        ];   
  public ledger:AccChartModel=new AccChartModel();                                         
  public lstOfledger:AccChartModel[];                                         

  constructor(
    private _fb:FormBuilder,
    private _modalService:NgbModal, 
    public _branchServices:BranchService,
    private _lowerGroupService:LowerGroupService,
    private _accChartService:AccChartService,
    private _tosterService:ToastrService,
  ) { }

  ngOnInit(): void {
    this.cerate();
    this.getAllBranch();
    this.getAllLowerGroup();
    this.getAllAccChartByComp();
  }
  saveLedger(){
   if(this.formVal.isCostCenter==true){
    this.formVal.isCostCenter=1;
   }
   else{
    this.formVal.isCostCenter=0;
   }
   if(this.formVal.isBillbyBill==true){
    this.formVal.isBillbyBill=1;
   }
   else{
    this.formVal.isBillbyBill=0;
   }
   if(this.formVal.isInventory==true){
    this.formVal.isInventory=1;
   }
   else{
    this.formVal.isInventory=0;
   }
   if(this.formVal.isEmployee==true){
    this.formVal.isEmployee=1;
   }
   else{
    this.formVal.isEmployee=0;
   }
   if(this.formVal.status==true){
    this.formVal.status=1;
   }
   else{
    this.formVal.status=0;
   }
   this.ledger=this.formVal;
   
    this._accChartService.saveLedger(this.ledger).subscribe(res=>{
     if(res){
      this._tosterService.success("Ledger Save Successfully");
      this.cerate();
     }
     else{
      this._tosterService.error("Fail to save");
     }
    })
  }

  getAllAccChartByComp(){
    this._accChartService.getAllAccChartByComp(this.compId).subscribe(res=>{
      this.lstOfledger=res as AccChartModel[];
      console.log("this.lstOfledger",this.lstOfledger);
    })
  }
  getAllLowerGroup(){
    this._lowerGroupService.getAllLowerGroup(this.compId).subscribe((res:any)=>{
      this.lstlowerGroup=res;
    })
  }
  getAllBranch(){
    this._branchServices.getBranchByCompId(this.compId).subscribe((res:any)=>{
      this.lstOfbranch=res.response;
    })
  }
  openModalForSave(event:any){
    this._modalService.open(event,{size: 'lg', windowClass: 'modal-xl'});
  }
  cerate(){
    this.ledgerForm=this._fb.group({
     id:[0,[]],      
     compId:[this.compId,[]],      
     lowerGroupId:[,[]],      
     accountName:[,[]],      
     aliasName:[,[]],      
     openningBalance:[,[]],      
     currencyId:[1,[]],      
     currencyRate:[,[]],      
     subLeadeger:[,[]],      
     isCostCenter:[,[]],      
     isBillbyBill:[,[]],      
     isInventory:[,[]],      
     isEmployee:[,[]],      
     status:[,[]],      
     accountId:[,[]],      
     branchId:[,[]],      
    })
  }
  get f(){
    return this.ledgerForm.controls;
  }
  get formVal(){
    return this.ledgerForm.value;
  }

}

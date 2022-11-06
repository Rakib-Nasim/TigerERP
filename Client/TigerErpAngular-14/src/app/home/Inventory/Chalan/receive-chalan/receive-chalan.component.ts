// import { ChallanType, OrderType } from 'src/app/common/projectEnum';

import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder } from '@angular/forms';

import { AccChartService } from './../../../../services/Accounting/acc-chart.service';
import { NgbDateCustomParserFormatter } from 'src/app/common/NgbDateParserFormatter';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-receive-chalan',
  templateUrl: './receive-chalan.component.html',
  styleUrls: ['./receive-chalan.component.css']
})
export class ReceiveChalanComponent implements OnInit {

 
 
  constructor(
    private fb: FormBuilder,
    private toaster: ToastrService,
    private _dateService: NgbDateCustomParserFormatter,
    public _modalService: NgbModal,
    private _toasterService: ToastrService,
    private _accChartService:AccChartService

  ) { }

  ngOnInit() {
    

  }

  getAllCustomerByCompId(){
    this._accChartService.getAllAccChartByComp(202,4).subscribe(res=>{

    })
  }


  }

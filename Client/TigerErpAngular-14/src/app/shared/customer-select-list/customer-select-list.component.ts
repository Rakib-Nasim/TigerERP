import { Component, OnInit } from '@angular/core';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-customer-select-list',
  templateUrl: './customer-select-list.component.html',
  styleUrls: ['./customer-select-list.component.css']
})
export class CustomerSelectListComponent implements OnInit {

  constructor(
    private _modalService:NgbModal,
  ) { }

  ngOnInit(): void {
  }
  
    onClickSearchBtn(template:any) {
      this._modalService.open(template, { size: 'lg' })
    }

}

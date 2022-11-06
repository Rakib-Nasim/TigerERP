import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Status } from 'src/app/common/projectEnum';
import { ToastrService } from "ngx-toastr";
import { UnitService } from 'src/app/services/unit.service';
import { UnitSetupModel } from 'src/app/models/UnitSetupModel';
import { Utility } from 'src/app/common/utility';
import html2canvas from 'html2canvas';
import { jsPDF } from 'jspdf';

@Component({
  selector: 'app-unit-setup',
  templateUrl: './unit-setup.component.html',
  styleUrls: ['./unit-setup.component.css']
})
export class UnitSetupComponent implements OnInit {

  unitEntryForm:FormGroup;
  compId: number = 202;
  isShow:boolean=false;
  lstStatus: any[] = [];
  selectedItemId: number = 0;
  searchText: string;
  lstUnitModel: UnitSetupModel[] = [];
  unitModel: UnitSetupModel | undefined;
  @ViewChild('content', { static: false }) content!: ElementRef;
  @ViewChild('tableListPdf', { static: false }) tableListPdf!: ElementRef;
  constructor(private fb: FormBuilder,
              private _modalService:NgbModal,
              private _utility:Utility,
              private _unitservice:UnitService,
              private _toasterService: ToastrService) { }

  ngOnInit(): void {
    this.lstStatus = this._utility.enumToArray(Status);
    this.getAllUnitBytCompId();
    this.creatForm();
  }

    getAllUnitBytCompId() {
    this._unitservice.getAllUnitByComp(202).subscribe(res => {
      this.lstUnitModel = res as UnitSetupModel[];

    });
  }

  
  saveUnit() {
      if (this.unitEntryForm.invalid) {
      this._toasterService.error("Please fill the all required fields", "Invalid submission");
      return;
    }
    let unit = new UnitSetupModel();
    unit = this.formVal;
    if (this.formVal.isBox == 1) {
      unit.isBox = 1;
    } else {
      unit.isBox = 0;
    }
    this._unitservice.saveUnit(this.formVal).subscribe((res: any) => {
      if (res) {
        this.getAllUnitBytCompId();
        this._toasterService.success("Save Successfully");
        this._modalService.dismissAll();
      }
    })
  }

    editUnitById(id: number, event: any) {
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
    this._unitservice.getUnitById(id).subscribe(res => {
      this.unitModel = res as UnitSetupModel;
      this.unitEntryForm.patchValue(this.unitModel);
    })
  }

    deleteUnit(index: number, modal: any) {
    this.selectedItemId = index;
    this._modalService.open(modal);
  }
  removeDetailFormRow(unitId: number) {
    this._unitservice.deleteUnit(unitId).subscribe(res => {
      this._toasterService.success("Delete Successfully");
      this.getAllUnitBytCompId();

    })
  }

  
  changeById(id: number) {
    this.unitModel = this.lstUnitModel.find(p => p.id == id);
    this.isShow = true;
  }


    viewPrint(id: number) {
    this.unitModel = this.lstUnitModel.find(p => p.id == id);
    this.makePdf();

  }

  makePdf() {
    let PDF = new jsPDF('p', 'mm', 'a4',);
    html2canvas(this.content.nativeElement, { scale: 3 }).then((canvas) => {
      const imageGeneratedFromTemplate = canvas.toDataURL('image/png');
      const fileWidth = 200;
      const generatedImageHeight = (canvas.height * fileWidth) / canvas.width;
      PDF.addImage(imageGeneratedFromTemplate, 'PNG', 0, 5, fileWidth, generatedImageHeight,);
      PDF.html(this.content.nativeElement.innerHTML);
      let blob = PDF.output("blob");
      window.open(URL.createObjectURL(blob));

    });
  }
  
  tableListPdfView() {
    let PDF = new jsPDF('p', 'mm', 'a4',);
    html2canvas(this.tableListPdf.nativeElement, { scale: 3 }).then((canvas) => {
      const imageGeneratedFromTemplate = canvas.toDataURL('image/png');
      const fileWidth = 200;
      const generatedImageHeight = (canvas.height * fileWidth) / canvas.width;
      PDF.addImage(imageGeneratedFromTemplate, 'PNG', 0, 5, fileWidth, generatedImageHeight,);
      PDF.html(this.tableListPdf.nativeElement.innerHTML);
      let blob = PDF.output("blob");
      window.open(URL.createObjectURL(blob));

    });
    this.isShow = false;
  }

  openModalForSave(event: any) {
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
  }

  reset(){
    this.creatForm();
  }

  creatForm() {
    this.unitEntryForm = this.fb.group({
      id: [0, []],
      compId: [this.compId, []],
      unitId: [0, []],
      unitName: ['', [Validators.required]],
      unitDescription: ['', []],
      isBox: [1, []],
      status: [1, []],
    })
  }

   get formVal() {
    return this.unitEntryForm.value;
  }
  get f() {
    return this.unitEntryForm.controls;
  }

}

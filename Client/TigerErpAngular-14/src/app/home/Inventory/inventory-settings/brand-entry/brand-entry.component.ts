import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { BrandModel } from 'src/app/models/BrandModel';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PublisherService } from 'src/app/services/publisher.service';
import { Status } from 'src/app/common/projectEnum';
import { ToastrService } from "ngx-toastr";
import { Utility } from 'src/app/common/utility';
import html2canvas from 'html2canvas';
import { jsPDF } from 'jspdf';

@Component({
  selector: 'app-brand-entry',
  templateUrl: './brand-entry.component.html',
  styleUrls: ['./brand-entry.component.css']
})
export class BrandEntryComponent implements OnInit {
  publisherEntryFrom: FormGroup;
  compId: number = 202;
  public brandId: number = 0;
  brandModel: BrandModel | undefined;
  lstbrandModel: BrandModel[] = [];
  lstStatus: any[] = [];
  isShow: boolean = false;
  selectedItemId: number = 0;
  searchText: string;
  @ViewChild('content', { static: false }) content!: ElementRef;
  @ViewChild('tableListPdf', { static: false }) tableListPdf!: ElementRef;

  constructor(
    private fb: FormBuilder,
    private publisherService: PublisherService,
    private _toasterService: ToastrService,
    private _modalService: NgbModal,
    private _utility: Utility
  ) { }

  ngOnInit(): void {
    this.lstStatus = this._utility.enumToArray(Status);
    this.creatForm();
    this.getAllBrandBytCompId();
  }
  getAllBrandBytCompId() {
    this.publisherService.getAllBrandByComp(202).subscribe(res => {
      this.lstbrandModel = res as BrandModel[];
    });
  }
  
  changeById(id: number) {
    this.brandModel = this.lstbrandModel.find(p => p.id == id);
    this.isShow = true;
  }
  savePublisher() {
    if (this.publisherEntryFrom.invalid) {
      this._toasterService.error("Please fill the all required fields", "Invalid submission");
      return;
    }
    this.publisherService.savePublisher(this.formVal).subscribe((res: any) => {
      if (res.status) {
        this.brandId = res.result as number;
        this.publisherService.getBrandById(this.brandId).subscribe(res => {
          this.isShow = true;
          this.brandModel = res as BrandModel;
        })
        this.resetAfterSave();
        this.getAllBrandBytCompId();
        this._toasterService.success("Save Successfully");
        this._modalService.dismissAll();
      }
      else {
        this._toasterService.error("Something is Wrong !! Please Try Again !!!");
      }
    })
  }
  editProductById(id: number, event: any) {
    this._modalService.open(event, { size: 'lg', windowClass: 'modal-xl' });
    this.publisherService.getBrandById(id).subscribe(res => {
      this.brandModel = res as BrandModel;
      this.publisherEntryFrom.patchValue(this.brandModel);
    })

  }
  delete(index: number, modal: any) {
    this.selectedItemId = index;
    this._modalService.open(modal);
  }
  removeDetailFormRow(brandId: number) {
    this.publisherService.deleteBrand(brandId).subscribe(res => {
      this._toasterService.success("Delete Successfully");
      this.getAllBrandBytCompId();

    })
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

  viewPrint(id: number) {
    this.brandModel = this.lstbrandModel.find(p => p.id == id);
    this.makePdf();

  }

  creatForm() {
    this.publisherEntryFrom = this.fb.group({
      id: [0, []],
      compId: [this.compId, []],
      brandName: [, [Validators.required]],
      description: ['', []],
      status: [1, []],
    })
  }
  reset() {
    this.creatForm();
  }
  resetAfterSave() {
    this.creatForm();
    this.isShow = false;
  }
  get formVal() {
    return this.publisherEntryFrom.value;
  }
  get f() {
    return this.publisherEntryFrom.controls;
  }
}

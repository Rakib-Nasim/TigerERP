import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';

import { BookEntryService } from 'src/app/services/book-entry.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { UnitService } from './../../services/unit.service';

@Component({
  selector: 'app-product-select-list',
  templateUrl: '../product-select-list/product-select-list.component.html',
  styleUrls: ['../product-select-list/product-select-list.component.css']
})
export class ProductSelectListComponent implements OnInit {
   compId:number=202;
  @Input() categoryId: number;
  @Input() productId: number;
  @Input() IsDisabled: boolean = false;
  @Input() productTabId: string;
  @Input() partyId: number;
  @Input() productSearchBtnId: string;
  @Output() onChange = new EventEmitter<any>()
  @Input() products: any[] = [];
  @Input() productlst: any[] = [];
  @Input() onChangeProductlst: any;
  @Input() showSearchBtn:boolean = true;
  @Input() width:string = '250px';
  filtered: any[] = [];
  companyId: number;
  priceRange = [1, 5000];
  allProducts:any[]=[];
  @Input() checkmoduleId:number=6;
  iSChecked:boolean = false;


  productUnitFormArray: FormArray;
  productModel = {
    id: null,
    categoryId: null,
    name: null,
    unitId: null,
    factor: null,
    costPrice: null,
    salePrice: null,
    productUnit: [],
    productType: 0,
    compId: this.compId
  }
  isNewProductAdded: boolean = false;

  constructor(
    private _bookServices: BookEntryService,
    private _unitService: UnitService,
    public modalService: NgbModal,
    private fb: FormBuilder,
    private toaster: ToastrService
  ) {
  }

  ngOnInit() {
    this.getProducts();
    this.productUnitFormArray = this.fb.array([]);
    this.getAllUnit();
  }
  getProducts() {
   this._bookServices.getAllBook(this.compId).subscribe((response: any) => {        
       this.filtered=response as any[];
       console.log("this.filtered",this.filtered);
     })
  }
  getAllUnit() {
    this.productUnitFormArray = this.fb.array([]);
    this._unitService.getUnitById(this.compId).subscribe((data => {
      this.productlst=data as any[];
      this.productlst.forEach(unit => {
        this.productUnitFormArray.push(new FormGroup({
          id: new FormControl(null),
          productId: new FormControl(null),
          unitId: new FormControl(unit.unitId),
          unitName: new FormControl(unit.unitName),
          factor: new FormControl(unit.unitFactor),
          isDefaultBillUnit: new FormControl(false),
          isDefaultChallanUnit: new FormControl(false),
          compId: new FormControl(this.companyId)
        }))
      })
    }))
  }
  onSelect(product: any) {
    if (product == null) {
      this.onChange.emit({ id: null, name: null });
      return;
    }
    this.onChange.emit(product);
    this.modalService.dismissAll();
  }

  eventTracker:NodeJS.Timer;
  searchforNgField(event:any){
    if (event.target.value && event.target.value != '') {
      if(this.companyId==57){
        this.filtered = this.allProducts.filter(p =>
          p.name.toLowerCase().startsWith(event.target.value.toLowerCase()))
        this.products = this.filtered;
        this.filtered = this.filtered;
      }else{
        this.filtered = this.allProducts.filter(p =>
          p.name.toLowerCase().includes(event.target.value.toLowerCase())
          )
          this.products = this.filtered;
        this.filtered = this.filtered;
      }
      if (this.filtered.length == 0) {
        this.productModel.name = event.target.value;
      }
    } else {
      this.filtered = [];
    }
  }
  search(event:any) {
      if(event.key=='Escape'){
        this.onChange.emit(null);
        this.modalService.dismissAll();
        return;
      }
      if(event.key=='Enter'){
        this.onChange.emit(null);
        this.modalService.dismissAll();
        return;
      }
     //Stop auto scroll
    if (event.shiftKey && (event.key == 'ArrowDown' || event.key == 'ArrowUp') && event.altKey) {
      if(this.eventTracker){
        clearInterval(this.eventTracker);
        this.eventTracker == null;
      }
      return;
    }
    //Start auto scroll to down
    if (event.shiftKey && event.key == 'ArrowDown' && this.filtered.length>0 && !this.eventTracker) {
      this.eventTracker = setInterval(()=>{
        // this.onArrowDownKey();
      },100);
      return;
    }
    //Start auto scroll to up
    if (event.shiftKey && event.key == 'ArrowUp' && this.filtered.length>0 && !this.eventTracker) {
      this.eventTracker = setInterval(()=>{
        // this.onArrowUpKey();
      },100);
      return;
    }
    //Select Up
    if (!event.shiftKey && event.key == 'ArrowUp' && this.filtered.length>0) {
      // this.onArrowUpKey();
      return;
    }
    //Select Down
    if(!event.shiftKey && event.key == 'ArrowDown' && this.filtered.length>0) {
      // this.onArrowDownKey();
      return;
    }
    //Focus Search field
    if(event.shiftKey && event.key=='S'){
      if(this.eventTracker){
        clearInterval(this.eventTracker);
      }
      // Helper.focusTextField('txtSearch');
      this.selectedRow = -1;
      return;
    }
   
    if (event.target.value && event.target.value != '') {
      if(this.companyId==57){
        this.filtered = this.products.filter(p =>
          p.name.toLowerCase().startsWith(event.target.value.toLowerCase()))
        this.products = this.filtered;
        this.filtered = this.filtered;
      }else{
        this.filtered = this.products.filter(p =>
          p.name.toLowerCase().match(event.target.value.toLowerCase())
          )
          this.products = this.filtered;
          this.filtered = this.filtered;
      }
      if (this.filtered.length == 0) {
        this.productModel.name = event.target.value;
      }
    } else {
      this.filtered = [];
    }
  }
  // onChangeDefaultUnit(unit:any) {
  //   if (!unit) {
  //     this.productModel.unitId = null;
  //     this.productModel.factor = null;
  //     this.resetUnitConvTable();
  //     return
  //   }
  //   this.productModel.unitId = unit.unitId;
  //   this.productModel.factor = unit.unitFactor;
  //   if (unit && unit.unitId) {
  //     this.productUnitFormArray.controls.find(u => u.value.unitId == unit.unitId).patchValue({
  //       isDefaultBillUnit: true,
  //       isDefaultChallanUnit: true,
  //       factor: unit.unitFactor
  //     })
  //     this.productUnitFormArray.controls.filter(u => u.value.unitId != unit.unitId).forEach(group => {
  //       group.patchValue({
  //         isDefaultBillUnit: false,
  //         isDefaultChallanUnit: false,
  //         factor: null
  //       })
  //     })
  //   } else {
  //     this.resetUnitConvTable();
  //   }
  // }

  onCheck(index:any, key:any) {
    this.productUnitFormArray.controls.forEach(group => {
      this.onChangeProductlst=group as any;
      this.onChangeProductlst.get(key).patchValue(false);
    })
    // this.productUnitFormArray.controls[index].get(key).patchValue(true);
  }
  resetUnitConvTable() {
    this.productUnitFormArray.controls.forEach(group => {
      group.patchValue({
        isDefaultBillUnit: false,
        isDefaultChallanUnit: false,
        factor: null
      })
    })
  }
  openSearchModal(template:any) {
    // document.getElementById(this.productSearchBtnId).blur();
    this.modalService.open(template,{size: 'lg', windowClass: 'modal-xl'});

  }
  // onSubmit() {
  //   if (!(this.productModel.categoryId && this.productModel.name && this.productModel.unitId)) {
  //     this.toaster.error('Invalid Submission', 'Fill all required filed');
  //     return;
  //   }
  //   var unitConv = this.productUnitFormArray.controls
  //     .filter(ctrl => (ctrl.get('isDefaultBillUnit').value || ctrl.get('isDefaultChallanUnit').value))
  //     .map(unit => unit.value);
  //   if (unitConv.some(unit => Number(unit.factor) <= 0) || Number(this.productModel.factor) <= 0) {
  //     return this.toaster.error('Unit factor should be greater than 0', 'Invalid Submission!');
  //   }
  //   this.productModel.productUnit = unitConv;
  //   this._bookServices.saveProduct(this.productModel).subscribe((response: any) => {
  //     if (response.status) {
  //       this.toaster.success('Saved', response.message);
  //       this.getProducts()
  //       Helper.focusTextField('txtSearch');
  //     } else {
  //       this.toaster.error('Failed', response.message);
  //     }
  //   })
  // }
  reset() {
    this.productModel = {
      id: null,
      categoryId: null,
      name: null,
      unitId: null,
      factor: null,
      costPrice: null,
      salePrice: null,
      productUnit: [],
      compId:this.compId,
      productType: 0
    }
  }

  selectedRow: number = -1;

  // onArrowDownKey() {
  //   this.selectedRow = (this.selectedRow + 1) % this.filtered.length;
  //   Helper.focusTextField('btnSelectProduct' + this.selectedRow)
  //   document.getElementById('row' + this.selectedRow).classList.add('selected-row')
  //   if (this.selectedRow > 0) {
  //     document.getElementById('row' + (this.selectedRow - 1)).classList.remove('selected-row')
  //   } else {
  //     document.getElementById('row' + (this.filtered.length - 1)).classList.remove('selected-row')
  //   }
  // }
  // onArrowUpKey() {
  //   this.selectedRow = this.selectedRow > 0 ? this.selectedRow-1 : this.filtered.length - 1;
  //   document.getElementById('row' + this.selectedRow).classList.add('selected-row')
  //   Helper.focusTextField('btnSelectProduct' + this.selectedRow)
  //   if (this.selectedRow >= this.filtered.length-1) {
  //     document.getElementById('row'+0).classList.remove('selected-row')
  //   } else {
  //     document.getElementById('row' + (this.selectedRow + 1)).classList.remove('selected-row')
  //   }
  // }

  closeModal(){
    if(this.eventTracker){
      clearInterval(this.eventTracker);
      this.eventTracker == null;
    }
    this.onChange.emit(null)
    this.getProducts();
    this.getAllUnit();
    this.modalService.dismissAll();
  }
  onEnterOrTabKeyDown(event: KeyboardEvent,  elementId: string) {
    if (event.key=='Tab' || event.key=='Escape' ) {
      this.modalService.dismissAll();
      // Helper.focusTextField(elementId);
      event.preventDefault();
    }
  }

}

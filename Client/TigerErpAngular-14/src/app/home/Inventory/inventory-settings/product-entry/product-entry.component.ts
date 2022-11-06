import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

import { AuthorService } from 'src/app/services/author.service';
import { BookEntryService } from 'src/app/services/book-entry.service';
import { BrandModel } from 'src/app/models/BrandModel';
import { CategoryModel } from 'src/app/models/CategoryModel';
import { CategoryService } from 'src/app/services/category.service';
import { ColorModel } from 'src/app/models/ColorModel';
import { IDropdownSettings, } from 'ng-multiselect-dropdown';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductModel } from '../../../../models/ProductModel';
import { PublisherService } from 'src/app/services/publisher.service';
import { Status } from 'src/app/common/projectEnum';
import { UnitService } from 'src/app/services/unit.service';
import { UnitSetupModel } from 'src/app/models/UnitSetupModel';
import { Utility } from 'src/app/common/utility';

@Component({
  selector: 'app-product-entry',
  templateUrl: './product-entry.component.html',
  styleUrls: ['./product-entry.component.css']
})
export class ProductEntryComponent implements OnInit {
  public bookEntryForm : FormGroup;
  public compId:number=202;
  public lstStatus:any[]=[];
  public dropdownSettings:IDropdownSettings = {
          singleSelection: false,
          idField: 'categoryId',
          textField: 'categoryName',
          selectAllText: 'Select All',
          unSelectAllText: 'UnSelect All',
          itemsShowLimit: 3,
          allowSearchFilter: true
        };
  public categoryItems:any[]=[];
  public authorItems:ColorModel[]=new Array<ColorModel>();
  public bookList:ProductModel[];
  public lstUnitModel: UnitSetupModel[]=new Array<UnitSetupModel>();
  public productUnitFormArray:any;
  public lstcategory:CategoryModel[]=new Array<CategoryModel>();
  public lstColorModel:ColorModel[]=new Array<ColorModel>();
  public ColorSetting :IDropdownSettings={
          singleSelection: false,
          idField: 'id',
          textField: 'colorName',
          selectAllText: 'Select All',
          unSelectAllText: 'UnSelect All',
          itemsShowLimit:3,
          allowSearchFilter: true
        };
  public lstPublisher:BrandModel[]=new Array<BrandModel>();
  constructor(
    private _bookentry:BookEntryService,
    private _categoryService:CategoryService,
    private _authorservice:AuthorService,
    private _publisherService:PublisherService,
    private _modalService:NgbModal,
    private _unitservice:UnitService,
    private _fb: FormBuilder,
    private _utility:Utility
  ) { 

  }

  ngOnInit(): void {
    this.getProduct();
    this.creatForm();
    this.getAllCategory();
    this.getAllColorBytCompId();
    this.getAllBrandBytCompId();
    this.getAllUnitBytCompId();
    this.lstStatus=this._utility.enumToArray(Status);
  
  }
  saveProduct(){
    let productUnitViewModel=(this.detailsFormAllVal as any[]).filter((p) => Number(p.factor) > 0 && (p.isDefaultChallanUnit==true || p.isDefaultBillUnit==true)
    )
    
    this.bookEntryForm.patchValue({
      productUnitViewModel:productUnitViewModel,
      categoryId:this.categoryItems[0].categoryId,
      colorId:this.authorItems[0].id
    })
    // console.log("this.bookEntryForm.value",this.bookEntryForm.value)
    this._bookentry.saveProduct(this.bookEntryForm.value).subscribe(res=>{
      
    })
  }


   getProduct(){
    this._bookentry.getAllBook(this.compId).subscribe((res:any)=>{
      if(res){
           this.bookList=res as any[];
      }
    })
   }

   getAllColorBytCompId() {
    this._authorservice.getAllColorByComp(this.compId).subscribe(res => {
      this.lstColorModel = res as ColorModel[];
    });
  }
  getAllBrandBytCompId() {
    this._publisherService.getAllBrandByComp(202).subscribe(res => {
      this.lstPublisher = res as BrandModel[];
    });
  }
   
  getAllCategory(){
    this._categoryService.getAllCategory(this.compId).subscribe((res:any)=>{
      if (res){
        this.lstcategory=res as CategoryModel[];
      }
    })
   }

   getAllUnitBytCompId() {
    this._unitservice.getAllUnitByComp(this.compId).subscribe(res => {
        this.lstUnitModel=res as UnitSetupModel[];

        this.lstUnitModel.forEach(unit => {
          this.productUnitFormArray.push(new FormGroup({
               id: new FormControl(0),
            productId: new FormControl(0),
            unitId: new FormControl(unit.unitId),
            unitName: new FormControl(unit.unitName),
            factor: new FormControl(unit.unitFactor),
            isDefaultBillUnit: new FormControl(false),
            isDefaultChallanUnit: new FormControl(false),
            compId: new FormControl(this.compId)
        }))
        })
       
    });
  }

  onCheck(index:number, key:any, checked:any) {
   
    if (checked) {
      this.productUnitFormArray.controls[index].get(key)!.patchValue(1);
    }
    else {
      this.productUnitFormArray.controls[index].get(key)!.patchValue(0);
    }

  }
   openModalForSave(event:any){
    this._modalService.open(event,{size: 'lg', windowClass: 'modal-xl'});
  }
 creatForm(){
  this.bookEntryForm=this._fb.group({
    id:[0,[]],
    productId:[0,[]],
    name:[,[]],
    productCategories:[this.categoryItems],
    productColor:[this.authorItems],
    brandId:[,[]],
    titel:[,[]],
    compId:[this.compId,[]],
    categoryId:[,[]],
    unitId:[,[]],
    description:[,[]],
    country:[,[]],
    costPrice:[,[]],
    salePrice:[,[]],
    productType:[,[]],
    moduleId:[,[]],
    order:[,[]],
    status:[1,[]],
    isDefaultBillUnit:[,[]],
    isDefaultChallanUnit:[,[]],
    factor:[,[]],
    colorId:[,[]],
    productUnitViewModel:[[]]
  })
  this.productUnitFormArray = this._fb.array([]);

 }

 get formVal(){
  return this.bookEntryForm.value;
}
get f(){
  return this.bookEntryForm.controls;
}

get detailsFormAllVal() {
  return this.productUnitFormArray.value;
}
   
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { CategoryModel } from 'src/app/models/CategoryModel';
import { CategoryService } from 'src/app/services/category.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductTypeModel } from 'src/app/models/ProductTypeModel';
import { Status } from '../../../../common/projectEnum';
import { ToastrService } from 'ngx-toastr';
import { Utility } from 'src/app/common/utility';

@Component({
  selector: 'app-category-entry',
  templateUrl: './category-entry.component.html',
  styleUrls: ['./category-entry.component.css']
})
export class CategoryEntryComponent implements OnInit {
  public categoryEntryForm:FormGroup;
  public categoryModel:CategoryModel=new CategoryModel();
  public lstcategory:CategoryModel[]=new Array<CategoryModel>();
  public compId:number=202;
  public lstproductType:ProductTypeModel[]=new Array<ProductTypeModel>() ;
  public lstStatus:any[]=[];

  constructor( private fb:FormBuilder,
               private _categoryService:CategoryService,  
               private _modalService:NgbModal,  
               private _toasterService:ToastrService,
               private _utility:Utility,    
    ) { }

  ngOnInit(): void {
    this.lstStatus=this._utility.enumToArray(Status);
    this.createForm();
    this.getAllCategory();
    this.getAllProductType();
  }
   getAllCategory(){
    this._categoryService.getAllCategory(this.compId).subscribe((res:any)=>{
    
        this.lstcategory=res as CategoryModel[];
      
    })
   }

   getAllProductType(){
    this._categoryService.getAllProductType(this.compId).subscribe(res=>{
      this.lstproductType!=res;
    })
   }

   saveCategory(){
    this.categoryModel=this.categoryEntryForm.value;
    if(this.formVal.isParent==true){
      this.categoryModel.isParent=1;
    }
    else{
      this.categoryModel.isParent=2;
    }
    this._categoryService.saveCategory(this.categoryModel).subscribe((res:any)=>{
      if(res){
       this._toasterService.success("Category Save Successfully");
       this._modalService.dismissAll();
       this.createForm();
      }
      else{
        this._toasterService.error("Category Not Save");
      }
    })
   }
   openModalForSave(event:any){
    this._modalService.open(event,{size: 'lg', windowClass: 'modal-xl'});
  }
  
  reset(){
    this.createForm();
  }

  createForm(){
    this.categoryEntryForm=this.fb.group({
      id:[0,[]],
      compId:[this.compId,[]],
      categoryId:[0,[]],
      parentId:[null,[]],
      categoryName:['',[]],
      description:['',[]],
      productType:[,[]],
      isProduction:[0,[]],
      isParent:[0,[]],
      status:[1,[]],
    })
  }
  get formVal(){
    return this.categoryEntryForm.value;
  }
  get f(){
    return this.categoryEntryForm.controls;
  }
  

}

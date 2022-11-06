import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HomeModule } from './../home.module';
import { InventoryIndexComponent } from './inventory-index/inventory-index.component';
import { InventoryRoutingModule } from './inventory-routing.module';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgModule } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from 'src/app/shared/shared/shared.module';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
         
  
    InventoryIndexComponent
  ],
  imports: [
    CommonModule,
    InventoryRoutingModule,
    SharedModule,
    HomeModule
  ]
})
export class InventoryModule { }

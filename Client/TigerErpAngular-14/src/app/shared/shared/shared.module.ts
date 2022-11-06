import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { CustomerSelectListComponent } from './../customer-select-list/customer-select-list.component';
import { DeleteConfirmationComponent } from './../delete-confirmation/delete-confirmation.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgModule } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductSelectListComponent } from './../product-select-list/product-select-list.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    ProductSelectListComponent,
    CustomerSelectListComponent,
    DeleteConfirmationComponent
  ],
  imports: [
    CommonModule,
    NgSelectModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NgMultiSelectDropDownModule.forRoot(),
    Ng2SearchPipeModule,
  ],
  exports:[
    ProductSelectListComponent,
    CustomerSelectListComponent,
    DeleteConfirmationComponent
  ]
})
export class SharedModule { }

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { HomeRoutingModule } from './home-routing.module';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgModule } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ReceiveChalanComponent } from './Inventory/Chalan/receive-chalan/receive-chalan.component';
import { SharedModule } from '../shared/shared/shared.module';
import { StartupComponent } from './startup/startup.component';

@NgModule({
  declarations: [
        StartupComponent,
    ReceiveChalanComponent,

  ],
  
  imports: [
    CommonModule,
    HomeRoutingModule,
    NgSelectModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    NgMultiSelectDropDownModule.forRoot(),
    Ng2SearchPipeModule,
    SharedModule,
    NgxSpinnerModule,
  ]
})
export class HomeModule { }

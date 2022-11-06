import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AccountingSetupRoutingModule } from './accounting-setup-routing.module';
import { CommonModule } from '@angular/common';
import { LowerGroupComponent } from './lower-group/lower-group.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgModule } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { SharedModule } from 'src/app/shared/shared/shared.module';

@NgModule({
  declarations: [LowerGroupComponent],
  imports: [
    CommonModule,
    AccountingSetupRoutingModule,
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
export class AccountingSetupModule { }

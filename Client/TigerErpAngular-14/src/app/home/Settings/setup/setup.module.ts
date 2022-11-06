import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CommonModule } from '@angular/common';
import { ModulesComponent } from './modules/modules.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgModule } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { PageEntryComponent } from './page-entry/page-entry.component';
import { SetupRoutingModule } from './setup-routing.module';
import { SharedModule } from 'src/app/shared/shared/shared.module';
import { BranchEntryComponent } from './branch-entry/branch-entry.component';

@NgModule({
  declarations: [PageEntryComponent,ModulesComponent, BranchEntryComponent],
  imports: [
    CommonModule,
    SetupRoutingModule,
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
export class SetupModule { }

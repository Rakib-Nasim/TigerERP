import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BrandEntryComponent } from './brand-entry/brand-entry.component';
import { CategoryEntryComponent } from './category-entry/category-entry.component';
import { ColorEntryComponent } from './color-entry/color-entry.component';
import { CommonModule } from '@angular/common';
import { GodownEntryComponent } from './godown-entry/godown-entry.component';
import { InventoryModule } from './../inventory.module';
import { InventorySettingsRoutingModule } from './inventory-settings-routing.module';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgModule } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ProductEntryComponent } from './product-entry/product-entry.component';
import { SharedModule } from './../../../shared/shared/shared.module';
import { UnitSetupComponent } from './unit-setup/unit-setup.component';

@NgModule({
  declarations: [
    UnitSetupComponent,
     GodownEntryComponent,
     ProductEntryComponent,
     CategoryEntryComponent,
     BrandEntryComponent,
     ColorEntryComponent
    ],
  imports: [
    CommonModule,
    InventorySettingsRoutingModule,
    NgMultiSelectDropDownModule.forRoot(),
    NgSelectModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    Ng2SearchPipeModule,
    InventoryModule,
    SharedModule
  ]
})
export class InventorySettingsModule { }

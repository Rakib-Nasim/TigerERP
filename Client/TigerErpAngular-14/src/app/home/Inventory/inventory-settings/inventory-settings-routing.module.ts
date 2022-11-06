import { RouterModule, Routes } from '@angular/router';

import { BrandEntryComponent } from './brand-entry/brand-entry.component';
import { CategoryEntryComponent } from './category-entry/category-entry.component';
import { ColorEntryComponent } from './color-entry/color-entry.component';
import { GodownEntryComponent } from './godown-entry/godown-entry.component';
import { NgModule } from '@angular/core';
import { ProductEntryComponent } from './product-entry/product-entry.component';
import { UnitSetupComponent } from './unit-setup/unit-setup.component';

const routes: Routes = [
    { path: 'category', component:CategoryEntryComponent},
    { path: 'product', component:ProductEntryComponent},
    { path: 'product-brand', component:BrandEntryComponent},
    { path: 'product-color', component:ColorEntryComponent},
    { path: 'godowns', component:GodownEntryComponent},
    { path: 'unit-setup', component:UnitSetupComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventorySettingsRoutingModule { }

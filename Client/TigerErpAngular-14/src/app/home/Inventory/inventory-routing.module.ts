import { RouterModule, Routes } from '@angular/router';

import { InventoryIndexComponent } from './inventory-index/inventory-index.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
    {path:'index', component:InventoryIndexComponent},
    { path:'inventory-setup',  loadChildren: () => import('./inventory-settings/inventory-settings.module').then(m => m.InventorySettingsModule) },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class InventoryRoutingModule { }

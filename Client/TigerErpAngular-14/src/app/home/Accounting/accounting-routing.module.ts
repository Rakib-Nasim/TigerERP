import { RouterModule, Routes } from '@angular/router';

import { AccountingIndexComponent } from './accounting-index/accounting-index.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  {path:'index', component:AccountingIndexComponent},
  { path:'accounting-setup',loadChildren: () => import('./accountingSetup/accounting-setup.module').then(m => m.AccountingSetupModule) },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountingRoutingModule { }

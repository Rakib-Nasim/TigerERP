import { RouterModule, Routes } from '@angular/router';

import { LedgerEntryComponent } from './ledger-entry/ledger-entry.component';
import { LowerGroupComponent } from './lower-group/lower-group.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  { path: 'lower-group', component:LowerGroupComponent},
  { path: 'ledger-entry', component:LedgerEntryComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountingSetupRoutingModule { }

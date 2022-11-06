import { RouterModule, Routes } from '@angular/router';

import { LowerGroupComponent } from './lower-group/lower-group.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
  { path: 'lower-group', component:LowerGroupComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountingSetupRoutingModule { }

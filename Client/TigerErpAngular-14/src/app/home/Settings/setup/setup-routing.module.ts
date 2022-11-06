import { RouterModule, Routes } from '@angular/router';

import { BranchEntryComponent } from './branch-entry/branch-entry.component';
import { ModulesComponent } from './modules/modules.component';
import { NgModule } from '@angular/core';
import { PageEntryComponent } from './page-entry/page-entry.component';

const routes: Routes = [
    { path: 'app-modules', component:ModulesComponent},
    { path: 'app-page', component:PageEntryComponent},
    { path: 'branch-entry', component:BranchEntryComponent},
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SetupRoutingModule { }

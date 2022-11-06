import { RouterModule, Routes } from '@angular/router';

import { ModulesComponent } from './modules/modules.component';
import { NgModule } from '@angular/core';
import { PageEntryComponent } from './page-entry/page-entry.component';

const routes: Routes = [
    { path: 'app-modules', component:ModulesComponent},
    { path: 'app-page', component:PageEntryComponent},
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SetupRoutingModule { }

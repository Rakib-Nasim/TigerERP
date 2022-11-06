import { RouterModule, Routes } from '@angular/router';

import { NgModule } from '@angular/core';
import { StartupComponent } from './startup/startup.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: StartupComponent }
  ])],
  exports: [RouterModule]
})
export class HomeRoutingModule { }

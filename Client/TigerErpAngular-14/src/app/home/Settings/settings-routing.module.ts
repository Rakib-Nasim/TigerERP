import { RouterModule, Routes } from '@angular/router';

import { NgModule } from '@angular/core';
import { SettingsIndexComponent } from './settings-index/settings-index.component';

const routes: Routes = [
    {path:'index', component:SettingsIndexComponent},
    { path: 'setting-setup',  loadChildren: () => import('./setup/setup.module').then(m => m.SetupModule) },
      
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SettingsRoutingModule { }

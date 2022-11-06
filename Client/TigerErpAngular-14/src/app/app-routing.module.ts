import { RouterModule, Routes } from '@angular/router';

import { Layout2Component } from './layout/layout2/layout2.component';
import { LayoutComponent } from './layout/layout.component';
import { NgModule } from '@angular/core';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

const routes: Routes = [
    { path: '', component:  Layout2Component,  loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
    { path: 'inventory', data:{moduleId:3},   component: LayoutComponent, loadChildren: () => import('./home/Inventory/inventory.module').then(m => m.InventoryModule) },
    { path: 'settings', data:{moduleId:1},   component: LayoutComponent, loadChildren: () => import('./home/Settings/settings.module').then(m => m.SettingsModule) },
    {path:'accounts', data:{moduleId:6}, component:LayoutComponent, loadChildren: () => import('./home/Accounting/accounting.module').then(m => m.AccountingModule) },
    {path: 'server-error', component: ServerErrorComponent},
    {path: 'not-found', component: NotFoundComponent},
    {path: '**', component: NotFoundComponent, pathMatch: 'full'},

  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { CommonModule } from '@angular/common';
import { HomeModule } from './../home.module';
import { InventoryIndexComponent } from './inventory-index/inventory-index.component';
import { InventoryRoutingModule } from './inventory-routing.module';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared/shared.module';

@NgModule({
  declarations: [
    InventoryIndexComponent
  ],
  imports: [
    CommonModule,
    InventoryRoutingModule,
    SharedModule,
    HomeModule
  ]
})
export class InventoryModule { }

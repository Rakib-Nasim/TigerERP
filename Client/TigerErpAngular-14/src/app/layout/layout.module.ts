import { BrowserModule } from '@angular/platform-browser';
import { Layout2Component } from './layout2/layout2.component';
import { LayoutComponent } from './layout.component';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SidenavComponent } from './sidenav/sidenav.component';
import { SidenavModule } from 'src/vendor/libs/sidenav/sidenav.module';

@NgModule({
    imports: [
    BrowserModule,
    RouterModule,
    SidenavModule,
    
  ],
  declarations: [
    Layout2Component,

    LayoutComponent,
    SidenavComponent,
    LayoutComponent

  ],
  

  exports:[

  ],
  providers: [],
})
export class LayoutModule { }

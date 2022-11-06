import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { ErrorInterceptor } from './Interceptors/exception-handler';
import { FooterOneComponent } from './layout/footer-one/footer-one.component';
import { HeaderOneComponent } from './layout/header-one/header-one.component';
import { HomeModule } from './home/home.module';
import { LayoutModule } from './layout/layout.module';
import { LoadingInterceptor } from './Interceptors/spinner-loader';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgModule } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgSelectModule } from '@ng-select/ng-select';
import { NgbDateCustomParserFormatter } from './common/NgbDateParserFormatter';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    // BookEntryComponent,
    HeaderOneComponent,
    FooterOneComponent,
    ServerErrorComponent,
    NotFoundComponent
    
  ],
  
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgSelectModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgMultiSelectDropDownModule.forRoot(),
    Ng2SearchPipeModule,
    LayoutModule,
    HomeModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule 
  ],
  exports:[
  ],
  providers: [
    NgbDateCustomParserFormatter,
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ], 
  bootstrap: [AppComponent,]
})
export class AppModule { }

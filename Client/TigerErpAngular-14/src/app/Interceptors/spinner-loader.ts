import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest
} from '@angular/common/http';
import { delay, finalize } from 'rxjs/operators';

import { Injectable } from '@angular/core';
import { LoaderService } from './../services/interceptorService/loader.service';
import { Observable } from 'rxjs';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private _loaderService: LoaderService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this._loaderService.show();
    return next.handle(request).pipe(
      finalize(() => {
        this._loaderService.hide();
      })
    )
  }
}
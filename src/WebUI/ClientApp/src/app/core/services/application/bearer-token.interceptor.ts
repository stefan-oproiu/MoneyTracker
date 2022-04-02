import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_BASE_URL } from '@models';
import { AuthService } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

@Injectable()
export class BearerTokenInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (request.url.startsWith(API_BASE_URL)) {
      return this.authService.getAccessTokenSilently().pipe(
        switchMap(token => next.handle(request.clone({ headers: request.headers.set('Authorization', `Bearer ${token}`) })))
      );
    }
    return next.handle(request);
  }
}

import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of, throwError } from 'rxjs';
import { AuthenService } from '../authentication/authen.service';
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class AuthenInterceptor implements HttpInterceptor {

  constructor(private authenService: AuthenService, private route: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authenService.getToken();
    req = req.clone({ headers: req.headers.set('Authorization', 'Bearer ' + token) });

    return next.handle(req).pipe(
      catchError(response => {
        if (response.status === 401) {
          this.route.navigate(['/login']);
        }
        return throwError(() => new Error(response));
      })
    )
  }

}

import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Router, NavigationExtras } from '@angular/router';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptors implements HttpInterceptor {
    constructor(private router: Router, private toastrservice: ToastrService){}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{
        return next.handle(req).pipe(
            catchError(error => {
                if (error){
                    if (error.status === 404){
                        this.toastrservice.error(error.error.errorMessage, error.error.statusCode);
                        this.router.navigateByUrl('/notfound');
                    }
                    if (error.status === 500){
                        const navigationExtras: NavigationExtras = {state: {error: error.error}};
                        this.router.navigateByUrl('/notfound', navigationExtras);
                    }
                }
                return throwError(error);
            }
            )
        );
    }
}

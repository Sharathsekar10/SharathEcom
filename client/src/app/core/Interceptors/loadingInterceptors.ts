import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusyService } from '../Service/busy.service';
import { finalize, delay } from 'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable()
export class LoadingInterceptors implements HttpInterceptor{
    constructor(private busyservice: BusyService){}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.busyservice.busy();
        return next.handle(req).pipe(
                    finalize(() => {
                            this.busyservice.idle();
                        }
                     )
        );
    }

}

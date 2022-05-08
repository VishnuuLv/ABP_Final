import { Injectable,Injector } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

constructor(private injector:Injector) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let userService=this.injector.get(UserService);
    let tokenizedReq=req.clone({
      setHeaders:{
        Authorization:'Bearer eyJbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJuYmYiOjE2NTE4Mzg1MDYsImV4cCI6MTY1MjQ0MzMwNiwiaWF0IjoxNjUxODM4NTA2fQ.F0wU1PCv59gRCNDilqS-Nc66sevvjEZibRpc2b1yrHY'
      }
    })
    return next.handle(tokenizedReq);
  }

}

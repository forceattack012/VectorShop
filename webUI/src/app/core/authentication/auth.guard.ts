import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenService } from './authen.service';


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authenService: AuthenService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean  {
    return true;
  }
}

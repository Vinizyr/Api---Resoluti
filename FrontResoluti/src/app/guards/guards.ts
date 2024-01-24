import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router
  ) { }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):
  boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {

    console.log(localStorage.getItem('tokenResoluti'))
    return this.verificarAcesso();
  }

  private verificarAcesso(){
    if (!localStorage.getItem('tokenResoluti')) {
      this.router.navigateByUrl('/login');
      alert("O usuário deve estar logado!")
      return false;
    }
    return true;
  }
}

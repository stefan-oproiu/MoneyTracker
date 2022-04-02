import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { ACCESS_DENIED_PATH } from '@models';
import { Store } from '@ngrx/store';
import { isAdmin, isChecked } from '@store/auth';
import { Observable } from 'rxjs';
import { filter, switchMap, take, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AdminGuard implements CanActivate {
  constructor(private store: Store, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    return this.store.select(isChecked).pipe(
      filter((x) => x),
      switchMap(() => this.store.select(isAdmin)),
      tap((x) => {
        if (!x) {
          this.router.navigate([ACCESS_DENIED_PATH]);
        }
      }),
      take(1)
    );
  }
}

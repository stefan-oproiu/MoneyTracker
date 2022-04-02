import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Store } from '@ngrx/store';
import { DestroyableDirective } from '@app/shared/destroyable-directive';
import { filter, switchMap, take, takeUntil } from 'rxjs/operators';
import { setUserClaims } from '@store/auth';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent extends DestroyableDirective {
  constructor(private authService: AuthService, private store: Store) {
    super();
    this.authService.isAuthenticated$
      .pipe(
        filter((x) => !x),
        takeUntil(this.destroyed$),
      )
      .subscribe(() => this.authService.loginWithRedirect());

    this.authService.isAuthenticated$
      .pipe(
        filter((x) => x),
        switchMap(() => this.authService.idTokenClaims$),
        take(1),
      )
      .subscribe((userClaims) =>
        this.store.dispatch(setUserClaims({ userClaims }))
      );
  }
}

import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { MeService } from '@services';
import { catchError, map, switchMap } from 'rxjs/operators';
import * as actions from './auth.actions';

@Injectable()
export class AuthEffects {
  constructor(
    private actions$: Actions,
    private meService: MeService,
  ) { }

  setUserClaims$ = createEffect(() => this.actions$.pipe(
    ofType(actions.setUserClaims),
    map(actions.requestUserCheck),
  ));

  checkUser$ = createEffect(() => this.actions$.pipe(
    ofType(actions.requestUserCheck),
    switchMap(() => this.meService.checkUser()),
    map(() => actions.userChecked()),
    catchError(() => []),
  ));
}

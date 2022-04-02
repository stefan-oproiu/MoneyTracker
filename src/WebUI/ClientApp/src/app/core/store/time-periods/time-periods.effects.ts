import { Injectable } from '@angular/core';
import { errorMessageValue, TimePeriod } from '@models';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { MeService } from '@services';
import { catchError, map, mergeMap } from 'rxjs/operators';
import * as actions from './time-periods.actions';

@Injectable()
export class MeTimePeriodsEffects {
  constructor(private actions$: Actions, private meService: MeService) {}

  getTimePeriods$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.getTimePeriods),
      mergeMap(() => this.meService.getTimePeriods()),
      map((timePeriods: TimePeriod[]) =>
        actions.getTimePeriodsSuccess({ timePeriods })
      ),
      catchError((error) => [
        actions.getTimePeriodsError({ errorMessage: errorMessageValue(error) }),
      ])
    )
  );
}

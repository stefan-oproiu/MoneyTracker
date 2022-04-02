import { TimePeriod } from '@models';
import { createAction, props } from '@ngrx/store';

export const getTimePeriods = createAction('[Time Periods] Get');
export const getTimePeriodsSuccess = createAction(
  '[Time Periods] Get Success',
  props<{ timePeriods: TimePeriod[] }>()
);
export const getTimePeriodsError = createAction(
  '[Time Periods] Get Error',
  props<{ errorMessage: string }>()
);

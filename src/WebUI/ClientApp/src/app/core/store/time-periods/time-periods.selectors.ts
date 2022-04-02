import { GET_RESOURCE_STATE, STORE_KEY_TIME_PERIODS } from '@models';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { isRequestFinished, isRequestPending } from '@store/common';
import {
  TimePeriodsState,
  selectAllTimePeriods,
} from './time-periods.reducers';

const selectTimePeriodsState = createFeatureSelector<TimePeriodsState>(
  STORE_KEY_TIME_PERIODS
);

export const allTimePeriods = createSelector(
  selectTimePeriodsState,
  selectAllTimePeriods
);

export const getTimePeriodsRequestPending = createSelector(
  selectTimePeriodsState,
  (state) => isRequestPending(GET_RESOURCE_STATE, state)
);

export const getTimePeriodsRequestFinished = createSelector(
  selectTimePeriodsState,
  (state) => isRequestFinished(GET_RESOURCE_STATE, state)
);

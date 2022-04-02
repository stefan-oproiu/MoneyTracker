import { STORE_KEY_AUTH, STORE_KEY_CATEGORIES, STORE_KEY_TIME_PERIODS } from '@models';
import { ActionReducerMap } from '@ngrx/store';
import * as fromAuth from './auth';
import * as fromCategories from './categories';
import * as fromTimePeriods from './time-periods';

export interface CoreState {
  [STORE_KEY_AUTH]: fromAuth.AuthState,
  [STORE_KEY_CATEGORIES]: fromCategories.CategoriesState,
  [STORE_KEY_TIME_PERIODS]: fromTimePeriods.TimePeriodsState,
};

export const reducers: ActionReducerMap<CoreState> = {
  [STORE_KEY_AUTH]: fromAuth.reducer,
  [STORE_KEY_CATEGORIES]: fromCategories.reducer,
  [STORE_KEY_TIME_PERIODS]: fromTimePeriods.reducer,
};

export const effects: any[] = [
  fromAuth.AuthEffects,
];

export const meEffects: any[] = [
  fromCategories.MeCategoriesEffects,
  fromTimePeriods.MeTimePeriodsEffects,
];

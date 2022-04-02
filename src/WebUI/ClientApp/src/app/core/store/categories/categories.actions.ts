import { MoneyCategory } from '@models';
import { createAction, props } from '@ngrx/store';

export const getCategories = createAction('[Categories] Get');
export const getCategoriesSuccess = createAction(
  '[Categories] Get Success',
  props<{ categories: MoneyCategory[] }>()
);
export const getCategoriesError = createAction(
  '[Categories] Get Error',
  props<{ errorMessage: string }>()
);

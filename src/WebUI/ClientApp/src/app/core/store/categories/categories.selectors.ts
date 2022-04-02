import { GET_RESOURCE_STATE, STORE_KEY_CATEGORIES } from '@models';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { isRequestFinished, isRequestPending } from '@store/common';
import { CategoriesState, selectAllCategories } from './categories.reducers';

const selectCategoriesState =
  createFeatureSelector<CategoriesState>(STORE_KEY_CATEGORIES);

export const allCategories = createSelector(
  selectCategoriesState,
  selectAllCategories
);

export const getCategoriesRequestPending = createSelector(
  selectCategoriesState,
  (state) => isRequestPending(GET_RESOURCE_STATE, state)
);

export const getCategoriesRequestFinished = createSelector(
  selectCategoriesState,
  (state) => isRequestFinished(GET_RESOURCE_STATE, state)
);

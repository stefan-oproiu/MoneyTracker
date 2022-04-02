import { ADMIN_ROLE, ROLE_NAME_IDENTIFIER, STORE_KEY_AUTH } from '@models';
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AuthState } from './auth.reducers';

const selectAuthState = createFeatureSelector<AuthState>(STORE_KEY_AUTH);

export const isAdmin = createSelector(
  selectAuthState,
  state => state?.userClaims && state.userClaims[ROLE_NAME_IDENTIFIER]?.includes(ADMIN_ROLE)
);

export const isChecked = createSelector(
  selectAuthState,
  state => state?.checked
);

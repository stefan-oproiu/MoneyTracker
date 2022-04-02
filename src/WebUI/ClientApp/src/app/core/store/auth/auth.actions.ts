import { createAction, props } from '@ngrx/store';

export const setUserClaims = createAction(
  '[Auth] Set User Claims',
  props<{ userClaims: any }>()
);
export const requestUserCheck = createAction('[Auth] Check User');
export const userChecked = createAction('[Auth] User Checked');

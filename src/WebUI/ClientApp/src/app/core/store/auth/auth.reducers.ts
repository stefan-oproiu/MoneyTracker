import { createReducer, on } from '@ngrx/store';
import * as actions from './auth.actions';

export interface AuthState {
  userClaims: any;
  checked: boolean;
}

const initialState: AuthState = {
  userClaims: null,
  checked: false,
};

export const reducer = createReducer(
  initialState,
  on(actions.setUserClaims, (state, { userClaims }) => ({
    ...state,
    ...{ userClaims },
  })),
  on(actions.userChecked, (state) => ({ ...state, checked: true })),
);

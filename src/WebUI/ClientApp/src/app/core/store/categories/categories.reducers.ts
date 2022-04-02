import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import {
  CREATE_RESOURCE_STATE,
  DELETE_RESOURCE_STATE,
  GET_RESOURCE_STATE,
  initialRequestState,
  MoneyCategory,
  requestError,
  requestPending,
  RequestState,
  requestSuccess,
  UPDATE_RESOURCE_STATE,
} from '@models';
import * as actions from './categories.actions';

export interface CategoriesState extends EntityState<MoneyCategory> {
  [GET_RESOURCE_STATE]: RequestState;
  [CREATE_RESOURCE_STATE]: RequestState;
  [UPDATE_RESOURCE_STATE]: RequestState;
  [DELETE_RESOURCE_STATE]: RequestState;
}

const adapter = createEntityAdapter<MoneyCategory>({
  selectId: (category) => category.id,
  sortComparer: (a, b) => a.type - b.type,
});

const initialState = adapter.getInitialState({
  [GET_RESOURCE_STATE]: initialRequestState,
  [CREATE_RESOURCE_STATE]: initialRequestState,
  [UPDATE_RESOURCE_STATE]: initialRequestState,
  [DELETE_RESOURCE_STATE]: initialRequestState,
});

export const reducer = createReducer(
  initialState,
  on(actions.getCategories, (state) => ({
    ...state,
    [GET_RESOURCE_STATE]: requestPending,
  })),
  on(actions.getCategoriesSuccess, (state, { categories }) => ({
    ...adapter.setAll(categories, state),
    [GET_RESOURCE_STATE]: requestSuccess,
  })),
  on(actions.getCategoriesError, (state, { errorMessage }) => ({
    ...state,
    [GET_RESOURCE_STATE]: requestError(errorMessage),
  }))
);

const { selectAll } = adapter.getSelectors();

export const selectAllCategories = selectAll;

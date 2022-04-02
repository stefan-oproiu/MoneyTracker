import {
  GET_RESOURCE_STATE,
  initialRequestState,
  requestError,
  requestPending,
  RequestState,
  requestSuccess,
  TimePeriod,
} from '@models';
import { createEntityAdapter, EntityState } from '@ngrx/entity';
import { createReducer, on } from '@ngrx/store';
import * as actions from './time-periods.actions';

export interface TimePeriodsState extends EntityState<TimePeriod> {
  [GET_RESOURCE_STATE]: RequestState;
}

const adapter = createEntityAdapter<TimePeriod>({
  selectId: (timePeriod) => timePeriod.name,
  sortComparer: (a, b) => a.startDate.getTime() - b.startDate.getDate(),
});

const initialState = adapter.getInitialState({
  [GET_RESOURCE_STATE]: initialRequestState,
});

export const reducer = createReducer(
  initialState,
  on(actions.getTimePeriods, (state) => ({
    ...state,
    [GET_RESOURCE_STATE]: requestPending,
  })),
  on(actions.getTimePeriodsSuccess, (state, { timePeriods }) => ({
    ...adapter.setAll(timePeriods, state),
    [GET_RESOURCE_STATE]: requestSuccess,
  })),
  on(actions.getTimePeriodsError, (state, { errorMessage }) => ({
    ...state,
    [GET_RESOURCE_STATE]: requestError(errorMessage),
  }))
);

const {selectAll} = adapter.getSelectors();

export const selectAllTimePeriods = selectAll;

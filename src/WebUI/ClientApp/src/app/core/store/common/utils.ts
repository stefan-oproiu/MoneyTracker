import { RequestStatus, RequestState, ResourceStateKey } from '@models';

export function hasStatus(
  status: RequestStatus,
  key: ResourceStateKey,
  state: { [K in ResourceStateKey]?: RequestState }
) {
  return state[key]?.status === status;
}

export function isRequestPending(
  key: ResourceStateKey,
  state: { [K in ResourceStateKey]?: RequestState }
) {
  return hasStatus(RequestStatus.Pending, key, state);
}

export function isRequestSuccessful(
  key: ResourceStateKey,
  state: { [K in ResourceStateKey]?: RequestState }
) {
  return hasStatus(RequestStatus.Success, key, state);
}

export function isRequestError(
  key: ResourceStateKey,
  state: { [K in ResourceStateKey]?: RequestState }
) {
  return hasStatus(RequestStatus.Error, key, state);
}

export function isRequestFinished(
  key: ResourceStateKey,
  state: { [K in ResourceStateKey]?: RequestState }
) {
  return isRequestSuccessful(key, state) || isRequestError(key, state);
}

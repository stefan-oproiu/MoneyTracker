import { environment } from '@env';

export const ROLE_NAME_IDENTIFIER =
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
export const ADMIN_ROLE = 'Admin';
export const API_BASE_URL = environment.apiBaseUrl;

export const STORE_KEY_AUTH = 'auth';
export const STORE_KEY_CATEGORIES = 'categories';
export const STORE_KEY_TIME_PERIODS = 'time-periods';

export const BAD_REQUEST_STATUS_CODE = 400;
export const UNAUTHORIZED_STATUS_CODE = 401;
export const FORBIDDEN_STATUS_CODE = 403;
export const NOT_FOUND_STATUS_CODE = 404;
export const CONFLICT_STATUS_CODE = 409;
export const SERVER_ERROR_STATUS_CODE = 500;

export const DEFAULT_HTTP_ERROR_MESSAGE: Map<number, string> = new Map([
  [BAD_REQUEST_STATUS_CODE, 'Bad request'],
  [UNAUTHORIZED_STATUS_CODE, 'Unauthorized request'],
  [FORBIDDEN_STATUS_CODE, 'Forbidden access'],
  [NOT_FOUND_STATUS_CODE, 'Not found'],
  [CONFLICT_STATUS_CODE, 'Conflict'],
  [SERVER_ERROR_STATUS_CODE, 'Server error'],
]);

export const GET_RESOURCE_STATE = 'getResourceState';
export const CREATE_RESOURCE_STATE = 'createResourceState';
export const UPDATE_RESOURCE_STATE = 'updateResourceState';
export const DELETE_RESOURCE_STATE = 'deleteResourceState';

export type ResourceStateKey =
  | typeof GET_RESOURCE_STATE
  | typeof CREATE_RESOURCE_STATE
  | typeof UPDATE_RESOURCE_STATE
  | typeof DELETE_RESOURCE_STATE;

import { DEFAULT_HTTP_ERROR_MESSAGE } from './constants';

export const errorMessageValue = (err: any) =>
  err?.error?.detail ?? DEFAULT_HTTP_ERROR_MESSAGE.get(err.status) ?? 'Error';

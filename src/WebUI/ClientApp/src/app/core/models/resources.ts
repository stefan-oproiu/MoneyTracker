export enum RequestStatus {
  Initial = 0,
  Pending = 1,
  Success = 2,
  Error = 3,
}

export interface RequestState {
  status: RequestStatus;
  errorMessage: string | null;
}

export const initialRequestState: RequestState = {
  status: RequestStatus.Initial,
  errorMessage: null,
};

export const requestPending = {
  status: RequestStatus.Pending,
  errorMessage: null,
};
export const requestSuccess = {
  status: RequestStatus.Success,
  errorMessage: null,
};
export const requestError = (errorMessage: string) => ({
  status: RequestStatus.Error,
  errorMessage,
});

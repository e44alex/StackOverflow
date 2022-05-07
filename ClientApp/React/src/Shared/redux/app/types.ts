export interface ErrorPayload {
    error: string,
    raisedError: Error,
}

export class AppState {
    authenticated: Boolean = false;
}
import { toastr } from "react-redux-toastr"
import { actions } from "./slice"

function onError(errorType: string) {
    toastr.error(errorType, '');
    console.error(errorType);
}

export function* appSaga() {
    yield onError(actions.error.type);
}
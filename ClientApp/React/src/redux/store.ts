import { configureStore } from '@reduxjs/toolkit';
import { reducer as questionReducer } from './questions/slice';
import createSagaMiddleware from 'redux-saga';
import {appSaga} from './app/saga';

const reduxSagaMonitorOptions = {};
const sagaMiddleware = createSagaMiddleware(reduxSagaMonitorOptions);
const { run: runSaga } = sagaMiddleware;

export const store = configureStore({
  reducer: {
    questionsLoader: questionReducer
  },
});

runSaga(appSaga)

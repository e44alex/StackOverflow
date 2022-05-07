import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import 'bootstrap/dist/css/bootstrap.css';
import App from './App';
import { store } from './Shared/redux/store';
import { Provider } from 'react-redux';
import ReduxToastr from 'react-redux-toastr';

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <App />

      <ReduxToastr transitionIn="fadeIn" transitionOut="fadeOut" />
    </Provider>
  </React.StrictMode>,
  document.getElementById('root'),
);


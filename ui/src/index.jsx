import * as React from 'react';
import * as ReactDOM from 'react-dom';
import App from './Components/App';
import './index.scss';
import { Provider } from 'react-redux'
import { createStore } from 'redux';
import reducer from './reducers';

const store = createStore(reducer);

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById('root')
);

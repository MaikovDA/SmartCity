import React from 'react';
import ReactDOM from 'react-dom';
import App from './Components/App';
import './index.scss';
import { Provider } from 'react-redux'
import { createStore } from 'redux';
import reducer from './reducers';
import { HashRouter } from 'react-router-dom';

const store = createStore(reducer);

ReactDOM.render(
  <HashRouter>
    <Provider store={store}>
      <App />
    </Provider>
  </HashRouter>,
  document.getElementById('root')
);

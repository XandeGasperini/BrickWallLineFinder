import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';

import { CssBaseline, ThemeProvider, createMuiTheme } from '@material-ui/core'

import { blue } from '@material-ui/core/colors';
import App from './App';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');


const theme = createMuiTheme({
  palette: {
    type: 'dark',
    primary: {
      main: blue[500]
    },
    secondary: {
      main: blue[500]
    }
  },
  typography: {
    fontFamily: 'Roboto'
  }
})

ReactDOM.render(
  <React.StrictMode>
    <CssBaseline />
    <ThemeProvider theme={theme}>
      <BrowserRouter basename={baseUrl}>
        <App />
      </BrowserRouter>
    </ThemeProvider>
  </React.StrictMode>,
  document.getElementById('root')
);


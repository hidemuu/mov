import * as React from "react";
import { Route } from 'react-router';
import { createGlobalStyle, ThemeProvider } from 'styled-components'
import { theme } from './commons/themes'
import { SWRConfig } from 'swr'
import GlobalSpinner from './components/organisms/GlobalSpinner'
import { AuthContextProvider } from './contexts/AuthContext'
import GlobalSpinnerContextProvider from './contexts/GlobalSpinnerContext'
import { ShoppingCartContextProvider } from './contexts/ShoppingCartContext'
import type { ApiContext } from './commons/@types/data'
import { fetcher } from './commons/utils/fetcher'
import Header from './components/organisms/Header'

import Home from './pages/Home';

// グローバルのスタイル
const GlobalStyle = createGlobalStyle`
html,
body,
textarea {
  padding: 0;
  margin: 0;
  font-family: -apple-system, BlinkMacSystemFont, Segoe UI, Roboto, Oxygen,
    Ubuntu, Cantarell, Fira Sans, Droid Sans, Helvetica Neue, sans-serif;
}

* {
  box-sizing: border-box;
}

a {
  cursor: pointer;
  text-decoration: none;
  transition: .25s;
  color: ${theme.colors.black};
}

ol, ul {
  list-style: none;
}
`

const context: ApiContext = {
    apiRootUrl: process.env.NEXT_PUBLIC_API_BASE_PATH || '/api/proxy',
  }

function App() {
    return (
      <div className="App">
        {/* <Header /> */}
            <header className="App-header">
                <p> Mov.AspReact-Test </p>
            </header>
            <Home />
        </div >
    );
}

export default App
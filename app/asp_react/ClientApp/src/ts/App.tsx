import * as React from "react";
import { Route } from 'react-router';

import Home from './pages/Home';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <p> Mov.AspReact </p>
            </header>
            <Home />
        </div >
    );
}

export default App
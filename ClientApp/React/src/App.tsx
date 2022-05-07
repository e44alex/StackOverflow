import React from 'react';
import './App.css';
import HomePage from './home-page/HomePage';
import AppNav from './Shared/components/app-nav/AppNav';

function App() {
  return (
    // <Router history={history}>
    //   <Routes>
    //     <Route path="/Home" element={HomePage}/>
    //   </Routes>
    // </Router>

    <div id="backDiv" className="appBody">
      <AppNav />
      <div className="col-md-8 offset-2 navColor">
        <HomePage />
      </div>
    </div>


  );
}

export default App;

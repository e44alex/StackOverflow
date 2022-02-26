import React from 'react';
import { Routes, Route, unstable_HistoryRouter as Router, Navigate } from 'react-router-dom';
import history from './utils/history'
import './App.css';
import HomePage from './Components/Pages/HomePage';

function App() {
  return (
    // <Router history={history}>
    //   <Routes>
    //     <Route path="/Home" element={HomePage}/>
    //   </Routes>
    // </Router>
    
    <div id="backDiv" className="appBody">

  <nav className="navbar navbar-expand-lg navbar-dark navColor">
    <img className="img-fluid" src="https://upload.wikimedia.org/wikipedia/commons/e/ef/Stack_Overflow_icon.svg" width="30"
      alt=""/>
    <a className="navbar-brand">Stackoverflow</a>
    <button className="navbar-toggler d-lg-none" type="button" data-toggle="collapse" data-target="#collapsibleNavId"
      aria-controls="collapsibleNavId" aria-expanded="false" aria-label="Toggle navigation">Collapse</button>
    <div className="collapse navbar-collapse" id="collapsibleNavId">
      <ul className="navbar-nav mr-auto mt-2 mt-lg-0">
        {/* <!-- Links on nav here --> */}
          <li className="btn btn-outline-light">+ Ask your question</li>
      </ul>
      <form className="form-inline my-2 my-lg-0">
        <input className="form-control mr-sm-2" type="text" placeholder="Search" name="searchText"/>
        <button className="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
      </form>
    </div>
  </nav>

  <div className="col-md-8 offset-2 navColor" >
    <HomePage/>
  </div>
</div>


  );
}

export default App;

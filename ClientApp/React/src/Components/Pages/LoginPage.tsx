import React from 'react'

export default class LoginPage extends React.Component {

    render() {
        return (<div id="loginComponent">
            <div className="col-md-7 offset-2 jumbotron jumbotron-fluid">
                <div className="col-md-8 offset-2 mt-4">
                    <form method="get">
                    <div className="form-group">
                        <label htmlFor="username">Email</label>
                        <input required type="email" className="form-control" name="usernname" id="username" aria-describedby="emailHelpId" placeholder="email@example.com" />
                        <div className="alert alert-danger">Email not valid</div>
                    </div>
                    <div className="form-group">
                        <label htmlFor="passwordInput">Password</label>
                        <input required type="password" className="form-control" name="pasword" id="passwordInput" placeholder="your password"/>
                        <div className="alert alert-danger">Password required</div>
                    </div>
                    <div className="col-md-2 offset-5">
                        <button type="submit" className="btn btn-primary mt-3">Login</button>
                    </div>
                    </form>
                </div>
            </div>
        </div>)
    }
}
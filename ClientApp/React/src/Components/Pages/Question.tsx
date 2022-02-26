import React from "react";

export default class Question extends React.Component {
  render() {
    return (
      <div>
        <div className="col-lg-10 offset-1">
          <h1 className="text-white display-1">Header</h1>
          <div>
            <p className="text-white">Discussion is opened</p>
            <p className="text-white">Discussion closed</p>
          </div>

          <div className="card text-white mb-5 bg-dark">
            <div className="card-header">
              <h2>Header</h2>
            </div>
            <div className="card-body"></div>
            <div className="card-footer">
              Created by: <a href="/" >author</a> on {"some dateTime"}
            </div>
          </div>
          <div>
            <h3>
              <p className="text-white">
                {" "}
                <b> answers</b>
              </p>
            </h3>

            <div className="mt-5">
              <div className="card text-white m-2 bg-dark">
                <div className="card-header">
                  <a href="/">author</a>
                </div>
                <div className="card-body"></div>
                <div className="card-footer">
                  <div className="row">
                    <div className="col-sm-8">Created on</div>
                    <div className="col-sm-2">
                      <p>Liked this</p>
                    </div>

                    <div className="col-sm-2">
                      <form method="post">
                        <input
                          type="button"
                          className="btn btn-secondary"
                          value="Like"
                        />
                      </form>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div>
            <div>
              <h4 className="text-white">Add your own answer:</h4>
            </div>
            <div>
              <form>
                <input name="questionId" hidden type="text" />
                <textarea
                  required
                  name="body"
                  className="form-control mb-5 bg-dark text-white"
                  placeholder="Enter your answer"
                ></textarea>
                <input type="submit" value="Send" className="btn btn-primary" />
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

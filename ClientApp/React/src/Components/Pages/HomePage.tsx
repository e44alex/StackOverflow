import React from "react";
import { Link } from "react-router-dom";
import { Question } from "../../Model/Question";
import { User } from "../../Model/User";

type MyProps = {};

type MyState = {
  questions: Question[];
};

export default class HomePage extends React.Component<MyProps, MyState> {
  constructor(props) {
    super(props);
    this.state = { questions: [] };
  }

  getTestQuestion(): Question[] {
    let testQuestion: Question = new Question();
    testQuestion.Topic = "Test Topic";
    testQuestion.DateCreated = new Date();
    testQuestion.Body = "Test question body";
    testQuestion.Creator = new User();
    testQuestion.Creator.Name = "TestUserName";
    testQuestion.Opened = true;
    testQuestion.Answers = [];

    return [
      testQuestion,
      testQuestion,
      testQuestion,
      testQuestion,
      testQuestion,
      testQuestion,
      testQuestion,
      testQuestion,
    ];
  }

  componentDidMount() {
    let data: Question[] = this.getTestQuestion();
    this.setState({ questions: data });
  }

  render() {
    return (
      <div id="home">
        <div className="offset-1">
          <h1 className="text-white">Questions</h1>
          <hr />
        </div>
        {this.state.questions.map((question) => {
          //for each question render card
          return (
            <div className="col-lg-10 offset-1 shadow-lg ">
              <div className="card-group">
                <div className="col-md-2">
                  <div className="card text-white text-center mt-2 bg-dark justify-content-center">
                    <div className="card-header">
                      <br />
                    </div>
                    <div className="card-body">
                      <h1 className="card-title">{question.Answers.length}</h1>
                    </div>
                    <div className="card-footer">answers</div>
                  </div>
                </div>
                <div className="card text-white mt-2 bg-dark">
                  <div className="card-header">
                    <h1 className="card-title">
                      {/* <Link to="/question">{question.Topic}</Link> */}
                    </h1>
                  </div>
                  <div className="card-body">
                    <p className="card-text">{question.Body}</p>
                  </div>
                  <div className="card-footer">
                    Created by <a href="/">{question.Creator.Name}</a> on{" "}
                    {question.DateCreated.toDateString()}
                  </div>
                </div>
              </div>
            </div>
          );
        })}
      </div>
    );
  }
}

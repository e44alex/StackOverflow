import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { DataServiceService } from '../Shared/data-service.service';
import { Answer, Question, User } from '../Shared/Model';
import { NgForm } from '@angular/forms'
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-Question',
  templateUrl: './Question.component.html',
  styleUrls: ['./Question.component.scss'],
})
export class QuestionComponent implements OnInit {
  question: Question;
  answer: Answer;

  constructor(
    private dataService: DataServiceService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.params.forEach((param: Params) => {
      if (param['id'] !== undefined) {
        this.dataService
          .getQuestion(param['id'])
          .then((x) => (this.question = x));
      }
    });

    document.getElementById("backDiv").attributes["height"]= "100%"

  }

  OnAnswerSubmit(form: NgForm){
    console.log(form)
    console.log(form.value)
    this.answer = new Answer();
    this.answer.body = form.value.body;
    this.answer.dateCreated = new Date();
    this.answer.id = Guid.create().toString();
    this.answer.question = new Question();
    this.answer.question.id = form.value.questionId
    this.answer.creator = new User();
    this.answer.creator.id = "cf18f8ad-cc48-457b-af75-08d8798dd0be"
    this.answer.creator.login ='test'
    console.log(JSON.stringify(this.answer))
    this.question.answers.push(this.answer)
    console.log(this.question)
    this.dataService.sendAnswer(this.answer);

    
  }
}

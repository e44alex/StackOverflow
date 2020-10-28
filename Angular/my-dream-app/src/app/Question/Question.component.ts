import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { DataServiceService } from '../Shared/data-service.service';
import { Question } from '../Shared/Model';

@Component({
  selector: 'app-Question',
  templateUrl: './Question.component.html',
  styleUrls: ['./Question.component.scss'],
})
export class QuestionComponent implements OnInit {
  question: Question;

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
  }
}

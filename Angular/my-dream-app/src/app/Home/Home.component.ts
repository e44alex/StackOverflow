import { Component, OnInit } from '@angular/core';
import { DataServiceService } from '../Shared/data-service.service';
import { Question } from '../Shared/Model';

@Component({
  selector: 'app-Home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.scss'],
})
export class HomeComponent implements OnInit {
  questions: Question[];

  constructor(private service: DataServiceService) {}

  ngOnInit() {
    this.service.getQuestions()
      .then((x) => (this.questions = x));
  }
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css']
})
export class AddQuestionComponent implements OnInit {

  questionTopic: string;
  questionBody: string

  constructor() { }

  ngOnInit(): void {

  }

  SendQuestion(){
    
  }
}

import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import {DataServiceService} from '../Shared/data-service.service';
import {Question} from '../Shared/Model';

@Component({
  selector: 'app-home',
  templateUrl: './Home.component.html',
  styleUrls: ['./Home.component.scss'],
})
export class HomeComponent implements OnInit {
  questions: Question[] = [];

  constructor(
    private service: DataServiceService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.service.getQuestions()
      .then((x) => {

        let searchText = "";
        this.route.params.forEach((param: Params) => {
          if (param['searchText'] !== undefined) {
            searchText = param['searchText'];
          }
        })

        if (searchText) {
          x = x.filter((element) => {
            return element.topic?.toLowerCase().includes(searchText.toLowerCase());

          })
        }
        this.questions = x.sort((a, b) => {
          if (a.lastActivity! > b.lastActivity!) {
            return -1;
          }
          if (a.lastActivity! < b.lastActivity!) {
            return 1;
          }
          return 0;
        });
      });
  }

  onClick() {
    console.log(this.questions)
  }
}

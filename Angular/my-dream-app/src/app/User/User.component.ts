import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { DataServiceService } from '../Shared/data-service.service';
import { User } from '../Shared/Model';

@Component({
  selector: 'app-User',
  templateUrl: './User.component.html',
  styleUrls: ['./User.component.scss']
})
export class UserComponent implements OnInit {

  user: User;

  constructor(private dataService: DataServiceService,
    private route: ActivatedRoute ) { }

  ngOnInit() {
    this.route.params.forEach((param: Params) => {
      if (param['id'] !== undefined) {
        this.dataService
          .getUser(param['id'])
          .then((user) => (this.user = user));
      }
    })
  }
}

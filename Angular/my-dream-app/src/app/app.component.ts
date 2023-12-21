import {Component} from '@angular/core';
import {LoginPartialComponent} from './login-partial/login-partial.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'my-dream-app';

  get getAuth() {
    return LoginPartialComponent.authenticated // TODO: this should be not inside of a component
  }

}

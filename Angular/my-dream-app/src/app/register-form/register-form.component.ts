import {Component} from '@angular/core';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent {

  name: string | undefined;
  surname: string | undefined;
  password: string | undefined;
  email: string | undefined;
  passwordConfirm: string | undefined;

  constructor() {
  }

}

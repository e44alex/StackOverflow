import {Component} from '@angular/core';
import {FormsModule, NgForm, ReactiveFormsModule} from "@angular/forms";
import {AuthServiceService} from "../Shared/auth-service.service";
import {CookieService} from "ngx-cookie-service";
import {Router} from "@angular/router";
import {Encryption} from "../Shared/Encryption";
import {LoginPartialComponent} from "../login-partial/login-partial.component";
import {NgIf} from "@angular/common";
import {AppModule} from "../app.module";

@Component({
  selector: 'app-sing-in-page',
  templateUrl: './sing-in-page.component.html',
  styleUrl: './sing-in-page.component.scss'
})
export class SingInPageComponent {
  username: string = "";
  password: string = "";

  formType: "login" | "register" = "login"

  constructor(
    private loginService: AuthServiceService,
    private cookieService: CookieService,
    private router: Router
  ) {
  }

  OnSubmit(loginForm: NgForm) {
    this.loginService
      .authenticate(this.username, this.password)
      .then((token: string) => {
        token = Encryption.Encrypt(token);
        this.cookieService.set('token', token);
        this.cookieService.set('username', this.username);
      });
    console.log(loginForm);
    LoginPartialComponent.authenticated = true;
    LoginPartialComponent.email = this.username;
    this.loginService.getId(this.username).then((value: string) => {
      LoginPartialComponent.id = value;
    });
    this.router.navigate(['/']);
  }
}

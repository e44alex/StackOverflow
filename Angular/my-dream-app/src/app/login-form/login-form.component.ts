import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthServiceService } from '../Shared/auth-service.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  username:string;
  password:string;

  constructor(loginService: AuthServiceService) { }

  ngOnInit(): void {
  }

  OnLogin(loginForm: NgForm){
    //loginService.Authenticate(username, password).then(() => {

    // })
    
    console.log(loginForm);
    
  }

}

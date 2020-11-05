import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-partial',
  templateUrl: './login-partial.component.html',
  styleUrls: ['./login-partial.component.css']
})
export class LoginPartialComponent implements OnInit {

  email:string;
  id:string;
  authenticated:boolean;

  constructor() { }

  ngOnInit(): void {
    //check cookies for email and token
    //if cookies there => set authenticated to true
    console.log("login partial init");
    
  }

}

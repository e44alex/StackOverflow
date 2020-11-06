import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Answer, Question, User } from './Model';


@Injectable({
  providedIn: 'root'
})
export class DataServiceService {
  

  constructor(private http: HttpClient) { }

  getQuestions(): Promise<Question[]>{
    console.log('getQuestions');
    
    return new Promise((resolve, reject) => {
      this.http.get('https://localhost:44360/api/Questions')
      .subscribe((data: Question[])=> {
        return resolve(data)
      });
    });   
  }

  getQuestion(id: string): Promise<Question>{
    return new Promise((resolve, reject) => {
      this.http.get('https://localhost:44360/api/Questions/'+id)
      .subscribe((data: Question)=> {
        return resolve(data)
      });
    });   
  }

  getAnswers(): Promise<Answer[]>{
    return new Promise((resolve, reject) => {
      this.http.get('https://localhost:44360/api/Answers')
      .subscribe((data: Answer[])=> {
        return resolve(data)
      });
    });   
  }

  getAnswer(id: string): Promise<Answer>{
    return new Promise((resolve, reject) => {
      this.http.get('https://localhost:44360/api/Questions/'+id)
      .subscribe((data: Answer)=> {
        return resolve(data)
      });
    });   
  }

  sendAnswer(answer: Answer){

    console.log("send answer invoked");
    const headers =  {
      headers: new  HttpHeaders({ 
        'Content-Type': 'application/json'})
    };
    return this.http.post<any>('https://localhost:44360/api/Answers', answer, headers).subscribe({
      next: data => {
        console.log(data)
      },
      error: error => {
        console.log(error)
      }
    });
  }

  getUser(id: string): Promise<User> {
    return new Promise((resolve, reject)=> {
      this.http.get('https://localhost:44360/api/Users/'+id).subscribe((data:User)=> {
        return resolve(data)
      })
    })
  }
}

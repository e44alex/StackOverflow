import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Answer, Question } from './Model';
import { resolve } from 'dns';
import { rejects } from 'assert';

@Injectable({
  providedIn: 'root'
})
export class DataServiceService {

  private questionsUrl = "/api/Questions"
  private answersUrl = "/api/Answers"
  private usersUrl = "/api/Users"
  
  constructor(private http: HttpClient) { }

  getQuestions(): Promise<Question[]>{
    return new Promise((resolve, reject) => {
      this.http.get('/api/Questions')
      .subscribe((data: Question[])=> {
        return resolve(data)
      });
    });   
  }

  getQuestion(id: string): Promise<Question>{
    return new Promise((resolve, reject) => {
      this.http.get('/api/Questions/'+id)
      .subscribe((data: Question)=> {
        return resolve(data)
      });
    });   
  }

  getAnswers(): Promise<Answer[]>{
    return new Promise((resolve, reject) => {
      this.http.get('/api/Answers')
      .subscribe((data: Answer[])=> {
        return resolve(data)
      });
    });   
  }

  getAnswer(id: string): Promise<Answer>{
    return new Promise((resolve, reject) => {
      this.http.get('/api/Questions/'+id)
      .subscribe((data: Answer)=> {
        return resolve(data)
      });
    });   
  }

}

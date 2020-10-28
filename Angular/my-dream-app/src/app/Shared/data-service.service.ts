import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Answer, Question } from './Model';

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
    this.http.post('https://localhost:44360/api/Answers', answer)
  }
}

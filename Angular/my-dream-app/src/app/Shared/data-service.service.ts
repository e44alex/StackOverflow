import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Answer, Question, User} from './Model';

@Injectable({
  providedIn: 'root',
})
export class DataServiceService {
  constructor(private http: HttpClient) {
  }

  getQuestions(): Promise<Question[]> {
    console.log('getQuestions');

    return new Promise((resolve) => {
      this.http
        .get('https://localhost:44360/api/Questions')
        .subscribe(value => resolve(value as Question[]))
    });
  }

  getQuestion(id: string): Promise<Question> {
    return new Promise((resolve) => {
      this.http
        .get('https://localhost:44360/api/Questions/' + id)
        .subscribe((value) => resolve(value as Question));
    });
  }

  getAnswers(): Promise<Answer[]> {
    return new Promise((resolve) => {
      this.http
        .get('https://localhost:44360/api/Answers')
        .subscribe((value) => {
          return resolve(value as Answer[]);
        });
    });
  }

  getAnswer(id: string): Promise<Answer> {
    return new Promise((resolve) => {
      this.http
        .get('https://localhost:44360/api/Questions/' + id)
        .subscribe((value) => {
          return resolve(value as Answer);
        });
    });
  }

  sendAnswer(answer: Answer, token: string) {
    console.log('send answer invoked');
    const headers = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + token,
      }),
    };
    return this.http
      .post<Answer>('https://localhost:44360/api/Answers', answer, headers)
      .subscribe({
        next: (data) => {
          console.log(data);
        },
        error: (error) => {
          console.log(error);
        },
      });
  }

  getUser(id: string): Promise<User> {
    return new Promise((resolve) => {
      this.http
        .get('https://localhost:44360/api/Users/' + id)
        .subscribe((value) => {
          return resolve(value as User);
        });
    });
  }

  sendQuestion(question: Question, token: string) {
    const headers = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + token,
      }),
    };
    return this.http
      .post<Question>(
        'https://localhost:44360/api/Questions',
        question,
        headers
      )
      .subscribe({
        error: (error) => {
          console.error(error); // TODO: add toast messages
        },
      });
  }

  likeAnswer(answerId: string, username: string, token: string) {
    const headers = {
      headers: new HttpHeaders({
        accept: '*/*',
        Authorization: 'Bearer ' + token,
      }),
    };
    return this.http
      .get(
        `https://localhost:44360/like?answerId=${answerId}&username=${username}`,
        headers
      )
      .subscribe({
        next: (data) => {
          console.log(data);
        },
        error: (error) => {
          console.log(error);
          alert('Not allowed')
        },
      });
  }

  updateUser(user: User, token: string) {
    const headers = {
      headers: new HttpHeaders({
        accept: '*/*',
        Authorization: 'Bearer ' + token,
      }),
    };
    this.http.put(`https://localhost:44360/api/Users/${user.id}`, user, headers).subscribe({
      next: (data) => {
        console.log(data);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}

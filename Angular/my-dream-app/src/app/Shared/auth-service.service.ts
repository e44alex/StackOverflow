import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  getId(username: string): Promise<string> {
    return new Promise((resolve) => {
      this.httpClient
        .get("https://localhost:44360/api/Users/getId/" + username) // TODO: put url to .env
        .subscribe((value) => resolve(value as string))
    })
  }

  constructor(private httpClient: HttpClient) {
  }

  authenticate(username: string, password: string): Promise<string> {
    return new Promise((resolve) => {
      this.httpClient.get("https://localhost:44360/token?username=" + username + "&password=" + password)
        .subscribe((value) => {
          return resolve((value as never)['access_token'])
        })
    })
  }
}

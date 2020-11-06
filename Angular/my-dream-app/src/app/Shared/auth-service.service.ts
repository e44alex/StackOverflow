import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private httpClient: HttpClient) { }

  authenticate(username: string, password:string): Promise<string>{
    return new Promise((resolve, reject) =>{
      this.httpClient.get("https://localhost:44321/token?user="+username+"&password="+password)
      .subscribe((data:string) => {
        return resolve(data)
      })
    })
  }

  checkLogin(username:string, token){
    return new Promise((resolve, reject) => {
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      })
      this.httpClient.get("https://localhost:44321/checkLogin?username="+username, {headers: headers });

    })
  }

}

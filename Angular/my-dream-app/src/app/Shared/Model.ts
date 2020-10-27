import { DecimalPipe } from '@angular/common';

export class User {
    Id: string;
    username: string;
    email:string;
    rating: number;
}

export class Question{
    topic: string;
    body: string;
    dateCreated: Date;
    lastActivity: Date;
    creator: User
}

export class Answer{
    body:string;
    dateCreated: string;

}
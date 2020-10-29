import { DecimalPipe } from '@angular/common';
import { Guid } from 'guid-typescript';

export class User {
    id: string;
    login: string;
    email:string;
    rating: number;
}

export class Question{
    id: string;
    topic: string;
    body: string;
    dateCreated: Date;
    lastActivity: Date;
    creator: User;
    opened: boolean;
    answers: Answer[]
}

export class Answer{
    id: string;
    question: Question;
    body:string;
    dateCreated: Date;
    creator: User;
    likers: User[];
}

export class AnswerLiker{
    id: string;
    user: User;
    answer: Answer
}
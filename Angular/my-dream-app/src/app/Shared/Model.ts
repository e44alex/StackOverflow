import { DecimalPipe } from '@angular/common';
import { Guid } from 'guid-typescript';

export class User {
    Id: Guid;
    login: string;
    email:string;
    rating: number;
}

export class Question{
    Id: Guid;
    topic: string;
    body: string;
    dateCreated: Date;
    lastActivity: Date;
    creator: User;
    opened: boolean;
    answers: Answer[]
}

export class Answer{
    Id: Guid;
    QuestionId: Guid;
    CreatorId: Guid;
    body:string;
    dateCreated: string;
    creator: User;
    likers: User[];
}

export class AnswerLiker{
    Id: Guid;
    user: User;
    answer: Answer
}
import { Answer } from 'src/Model/Answer';

export interface User {
  Id: string;
  Login: string;
  Name: string;
  Surname: string;
  PhoneNumber: string;
  Email: string;
  Rating: number;
  DateRegistered: Date;
  Experience: number;
  Position: string;
}

export interface Question {
  Id: string;
  Topic: string;
  Body: string;
  DateCreated: Date;
  LastActivity: Date;
  Creator: User;
  Opened: boolean;
  Answers: Answer[];
}

export interface AnswerLiker {
  id: string;
  user: User;
  answer: Answer;
}


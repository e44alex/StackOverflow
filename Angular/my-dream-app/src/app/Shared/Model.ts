export class User {
  id: string | undefined;
  login: string | undefined;
  name: string | undefined;
  surname: string | undefined;
  phoneNumber: string | undefined
  email: string | undefined;
  rating: number | undefined;
  dateRegistered: Date | undefined;
  experience: number | undefined;
  position: string | undefined
}

export class Question {
  id: string | undefined;
  topic: string | undefined;
  body: string | undefined;
  dateCreated: Date | undefined;
  lastActivity: Date | undefined;
  creator: User | undefined;
  opened: boolean | undefined;
  answers: Answer[] | undefined
}

export class Answer {
  id: string | undefined;
  question: Question | undefined;
  body: string | undefined;
  dateCreated: Date | undefined;
  creator: User | undefined;
  users: User[] | undefined;
}

export class AnswerLiker {
  id: string | undefined;
  user: User | undefined;
  answer: Answer | undefined
}

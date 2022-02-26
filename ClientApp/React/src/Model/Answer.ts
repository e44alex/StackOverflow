import { Question } from "./Question";
import { User } from "./User";


export class Answer {
    Id!: string;
    Question!: Question;
    Body!: string;
    DateCreated!: Date;
    Creator!: User;
    Users!: User[];
}

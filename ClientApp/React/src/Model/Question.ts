import { User } from "./User";
import { Answer } from "./Answer";


export class Question {
    Id!: string;
    Topic!: string;
    Body!: string;
    DateCreated!: Date;
    LastActivity!: Date;
    Creator!: User;
    Opened!: boolean;
    Answers!: Answer[];
}

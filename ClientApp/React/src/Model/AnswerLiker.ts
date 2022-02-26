import { Answer } from "./Answer";
import { User } from "./User";


export class AnswerLiker {
    id!: string;
    user!: User;
    answer!: Answer;
}

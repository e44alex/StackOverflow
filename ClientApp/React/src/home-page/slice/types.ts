import { Question } from 'src/Model/Question';


export class QuestionState {
    questions: Question[] = [];
    selectedQuestion: Question = new Question();
}

export class LoadQuestionPayload {
    questionId!: string;
}

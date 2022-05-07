import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Question } from 'src/Shared/Question';
import { LoadQuestionPayload, QuestionState } from 'src/Components/Pages/home-page/questions/types';

export const initialState : QuestionState = {
    questions: [],
    selectedQuestion: new Question()
};

const slice = createSlice({
    name: 'questions',
    initialState,
    reducers: {
        loadList(state, action: PayloadAction){
        },
        loadSingle(state, action: PayloadAction<LoadQuestionPayload>){
        }
    }
})

export const { actions, reducer, name: sliceKey } = slice;
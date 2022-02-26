import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { Question } from "../../Model/Question";
import { LoadQuestionPayload, QuestionState } from "./types";

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
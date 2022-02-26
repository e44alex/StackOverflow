import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AppState, ErrorPayload,  } from "./types";

export const initialState: AppState = {
    authenticated: false,
}

const slice = createSlice({
    name: 'questions',
    initialState,
    reducers: {
        error(state, action: PayloadAction<ErrorPayload>){
        },
    }
})

export const { actions, reducer, name: sliceKey } = slice;
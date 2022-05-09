import {configureStore} from '@reduxjs/toolkit'
import userReducer from './shopSlice'

export const store = configureStore({
    reducer: userReducer,
});
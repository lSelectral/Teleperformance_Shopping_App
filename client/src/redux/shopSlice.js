import {createSlice} from '@reduxjs/toolkit'

const shopSlice = createSlice({
    name: "shop",
    initialState: {
        shoppingLists: [],
        products: [],
        categories:  [],
        shoppingListProducts: []
    },
    reducers: {
        updateShoppingLists: (state,action) => {
            state.shoppingLists = action.payload;
        },
        updateProducts: (state,action) => {
            state.products = action.payload;
        },
        updateCategories: (state,action) => {
            state.categories = action.payload;
        },
        updateShoppingListProducts: (state,action) => {
            state.shoppingListProducts = action.payload;
        }
    }
})

export const {
    updateShoppingLists, 
    updateProducts,
    updateCategories,
    updateShoppingListProducts
} = shopSlice.actions;

export default shopSlice.reducer;
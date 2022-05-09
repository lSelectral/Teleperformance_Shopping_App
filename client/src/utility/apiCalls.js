import axios from "axios";

const base_url = process.env.REACT_APP_API_URL;
export const categoryEndpoint = base_url + "categories";
export const productEndpoint = base_url + "products";
export const shoppingListEndpoint = base_url + "ShoppingLists";
export const shoppingListProductEndpoint = base_url + "shoppinglistproducts";
export const userEndpoint = base_url + "users";

const TOKEN = localStorage.getItem("token") ? localStorage.getItem("token") : process.env.TOKEN_DATA;
// const TOKEN = process.env.TOKEN_DATA;

/*let user = JSON.parse(sessionStorage.getItem('data'));
const token = user.data.id;*/


const headers = {
    'Content-Type': 'application/json',
    'Authorization': TOKEN
}

const asyncPromiseBuilder = async (promise, onSuccessful = null, onError = null) => {
    try{
        const response = await promise;
        if (onSuccessful !== null){
            onSuccessful(response.data);
        }
        console.log(response);
        return response.data;
    } catch (err){
        console.log(err);
        onError(err);
        return [{}];
    }
}

export const GETALL = (endpoint, onSuccessful, onError) =>
    asyncPromiseBuilder(axios.get(endpoint, {headers} ), onSuccessful, onError);
export const POST = (endpoint, onSuccessful, data, onError) =>
    asyncPromiseBuilder(axios.post(endpoint, data, { headers}), onSuccessful, onError);
export const UPDATE = (endpoint, onSuccessful, data, onError) =>
    asyncPromiseBuilder(axios.put(endpoint, data, { headers }), onSuccessful, onError);
export const DELETE = (endpoint, onSuccessful, data, onError) =>
    asyncPromiseBuilder(axios.delete(endpoint + "?id=" + data, { headers }), onSuccessful, onError);
    
export const GET_ALL_SHOPPING_LIST_FROM_USER = (onSuccessful, onError) =>
    asyncPromiseBuilder(axios.get(`${shoppingListEndpoint}/users/${localStorage.getItem('userId')}`, {headers} ), onSuccessful, onError);
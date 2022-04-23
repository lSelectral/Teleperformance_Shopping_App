import axios from "axios";

const base_url = process.env.REACT_APP_API_URL;
export const categoryEndpoint = base_url + "categories";
export const productEndpoint = base_url + "products";
export const shoppingListEndpoint = base_url + "shoppinglists";
export const shoppingListProductEndpoint = base_url + "shoppinglistproducts";
export const userEndpoint = base_url + "users";

let TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImFkbWluQGhvdG1haWwuY29tIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJuYmYiOjE2NTA3NDgyMjQsImV4cCI6MTY1MTE4MDIyNCwiaXNzIjoid3d3LnNpdGUuY29tIiwiYXVkIjoid3d3LnNpdGUuY29tIn0.YDBI5DJnl6XoaPviaJKnmjG7yA40cPDYaMAfND0GOVc";

const asyncPromiseBuilder = async (promise, onSuccessfull = null) => {
    try{
        const response = await promise;
        if (onSuccessfull !== null){
            onSuccessfull(response.data);
        }
        console.log(response.data);
        return response.data;
    } catch (err){
        console.log(err);
        return [{}];
    }
}

export const GETALL = (endpoint, onSuccessfull) => 
    asyncPromiseBuilder(axios.get(endpoint, { headers: {Authorization: `Bearer ${TOKEN}`}}), onSuccessfull);
export const ADD = (endpoint, onSuccessfull, data) => 
    asyncPromiseBuilder(axios.post(endpoint, { headers: {Authorization: `Bearer ${TOKEN}`}}, data), onSuccessfull);
export const UPDATE = (endpoint, onSuccessfull, data) => 
    asyncPromiseBuilder(axios.put(endpoint, { headers: {Authorization: `Bearer ${TOKEN}`}}, data), onSuccessfull);
export const DELETE = (endpoint, onSuccessfull, data) => 
    asyncPromiseBuilder(axios.delete(endpoint + "?id=" + data, { headers: {Authorization: `Bearer ${TOKEN}`}}), onSuccessfull);

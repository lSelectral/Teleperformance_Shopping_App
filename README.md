# TELEPERFORMANCE SHOPPING APP

This project created for Teleperformance .Net Bootcamp Final Project
Purpose of this project is creating an app for shopping and making it easy and intuitive as possible.

![](https://www.pngitem.com/pimgs/m/620-6206666_teleperformance-logo-hd-png-download.png)


### Features
- Users can register and login
- Users can create shopping list and add, delete and update producsts from list
- Admin can create, edit and update products and categories from user interface.
- System protected by JWT
- ASP.NET, C#, AutoMapper, MSSQL, React, Redux, Axios used mainly.

---

Project created by 3 part,
1. ASP.NET Backend (C#, .NET 6)
2. MSSQL Local Database
3. React Frontend

---
> HOW TO RUN


- If you want you can edit connection string and token option

```
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=ShoppingDB; Integrated Security=true"
  },
  "TokenOption": {
	  "Issuer": "www.teleperformance.com",
	  "Audience": "www.teleperformance.com",
	  "Key": "teleperformanceteleperformancete",
	  "Expiration": 999
  }
```
Build the project. (This will install dependencies)
Before starting the project, you should create migration and DB.

Run these commands in order:
1. `Add-Migration Initial`
2. `Update-Database`

Then open the ASP.NET Project directory then in the command line run `dotnet run`
After API started, you can explore API from [Swagger API](https://localhost:7242/swagger/index.html)

For using frontend, open the `client` folder and inside,

1. Either run `npm install` or `yarn`

2. Either run `npm start` or `yarn start`

3. This will open the http://localhost:3000 in the default browser.

4. When using the frontend first time, it will redirect you to `Login`page.

5. You can either insert user manually (for admin privilege you should), or you can click the register link below `LOGIN` button. 

6. Go to homepage then you can use the User Interface as you want.

7. For accessing admin pages, you need admin account that should be created by hand in the database. Frontend doesn't allow admin account privilege. (ADMIN account mails have to contain **`admin`** in the email address.)

---

## API

API is completely decoupled from frontend so frontend easily interchangable.
API response always have same pattern like below (**data** - **errors**):
>Categories Endpoint

```
{
    "data": [
        {
            "id": 2,
            "name": "Food"
        },
        {
            "id": 3,
            "name": "Game"
        }
    ],
    "errors": null
}
```

---
### DATABASE DIAGRAM

MSSQL database created by Code-First approach with the help of EF Core.
Created Database diagram can be found below

![](https://i.imgur.com/QHtq4Ry.png)

---

Backend server created by C# in .Net 6 Framework.

MediatR and Generic Repository Pattern used in
In this project MediatR and Generic Repository ve Controller Pattern used.

### ENDPOINTS

Because of controller base is fully generic, most of the CRUD operations are same.
Non - Generic ones will be shown in respective endpoints.

|HTTP|DESCRIPTION|RETURNS
|---|---|---|
|GET| Get All  | `ResponseDto<List<T>>` 
|GET| Get By Id | `ResponseDto<T>` 
|GET| Get By Search | `ResponseDto<List<T>>`  
|POST| Add | `ResponseDto<int>`
|PUT| Update | `ResponseDto<NoContent>`
|DELETE| Delete | `ResponseDto<NoContent>`

#### Shopping Lists Endpoint

|HTTP|DESCRIPTION|RETURNS
|---|---|---|
|GET| Get By User Id  | `ResponseDto<ShoppingList>` 

#### Users  Endpoint

|HTTP|DESCRIPTION|RETURNS
|---|---|---|
|POST| Send login information for JWT (Token)  | `ResponseDto<[Token, UserID]>` 


### Folder Structure

- **`Controllers`**
> Controller for defining all endpoints with custom generic base controller class and child classes
- **`Core`**
> Database context for EF Core Code First Approach
-  **`DTOs`**
> Contains **Data Transfer Objects** between layers
- **`Mappers`**
> AutoMapper class for mapping objects to each other
- **`Middlewares`**
> Global **Logging** and **Error Handling** middleware classes
- **`Models`**
> Contains model for data handling and defining (Also contains Insert and Update models)
- **`Repositories`**
> Contains all database functions for querying and altering the database. Generic repository used
- **`Services`**
> Authentication services and Mediatr Pattern Query and Commands 
- **`ViewModels`**
> Contains all viewmodels for transferring data to the ui and isolating unwanted data to exposing to the ui

## FRONTEND

Frontend uses React.JS, Redux, Axios, React-Router-DOM and MUI.
d

# PayCalc
An app to calculate your pay using React, C# and Sql Server. In short I got sick of having to calculate my pay using a calculator like a normal person and didn't want to download an application like a pleb, so I am gonna built my own. 

### Cool stuff for nerd (like me)
- I am using react with vite because CRA is old and slimy.
- I am using the repository pattern with DTO objects on the api. this is to mitigate an SQL Injection vulnerability created by exposing the dbcontext.
- I am planning on using JWTs to authorize the users.
- I am going to put myself through the pain of unit testing the api.

### file structure
```
paycalc_api
├── paycalc.core // seperate the business logic from the api
│   ├── entities
│   ├── jwt
│   ├── mapper
│   ├── dto
│   ├── services
│   └── dbcontext
├── paycalc.api // the actual api
│   └── controllers 
├── paycalc.tests // this is where we test the services and the dbcontext
│   ├── program.cs 
│   └── using.cs
└── paycalc_api.sln
```
UNDER CONSTRUCTION / NOT YET READY FOR USE

ABOUT:
This project is a simple skeleton for Angular + .NET Core. All of the necessary
error handling or logic has not been added so use it with caution. This project
is not supposed to be user friendly or follow the best practices in Angular routing or
security. It is only to be used for learning basic concepts for students or new people 
in web development. A lot of the stuff shown in this project is very standard basic stuff
and should be easily understandable. Everything you see in this project should be something that
you have seen in your previous projects in terms of naming, folder hierarchy or logic or you will 
see in your future projects whether they are university projects or real world applications. 
For all questions or help, send an email to kurosh_farsimadan@yahoo.com. I also provide tutorial
sessions to those who need help in programming for free. 

CORE CONCEPTS:
- Registration
- Login
- Authentication
- Authorization

PROJECT TECHNOLOGY STACK:
- Angular 11
- Angular Material? -> Project setup with and without
- Toastr
- .NET Core
- HTML5
- CSS3
- LESS?
- Entity Framework
- Swagger
- JWT Authentication
- Signal R?
- Queue / Rabbit MQ?
- Pipeline?
- Jenkins?
- SQL Server
- More...

BASIC INSTRUCTIONS: 

1. Install "Microsoft SQLServer" from the package manager

2. Install https://www.nuget.org/packages/dotnet-ef/ OR 
dotnet tool install dotnet-ef -g

2.2 Run "dotnet ef migrations add InitialCreate -o Data/Migrations"
in the root of the project folder. To undo use "ef migrations remove"

2.3 Create your database and configure the configuration string using SQL Server through
View -> SQL Server Object Explorer

3. Run "dotnet ef database update"

4. Run the dummy data test script insertion for the database

5. Install Postman for testing the API

6. Run the project

BONUS
7. Run the project using HTTPS/SSL. Generate certificate for this
and add the necessary configuration


In VSCode run:
    dotnet new console -o EFexemplo   
    >> cd EFexemplo
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet tool update --global dotnet-ef 
    dotnet ef migrations add InitialCreate --context CompanyContext
    dotnet ef database update --context CompanyContext

Data base will be saved at:
    C:\Users\<Name>\AppData\Local\DBNAME.db

To add properties use:
    dotnet ef migrations add Add"Property Name Here"ToModel --context CompanyContext
    then update migration

Migration data is saved in namespace Project.Migrations
Entity Manager is defined in namespace Project.Data
Entity models are defined in namespace Project.Models

CRUD API examples are in Program.cs, always save changes after operations
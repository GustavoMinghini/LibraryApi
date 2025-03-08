Technologies Used
ASP.NET Core OpenAPI – For creating APIs with support for OpenAPI specifications.
Entity Framework Core – For ORM support and data management.
Entity Framework Core SQL Server – For SQL Server database integration.
Entity Framework Core Tools – For running EF Core commands and migrations.
Scalar.ASP.NET Core – For enhanced functionality with ASP.NET Core.
Features
Retrieve an address by its postal code (CEP) using the Correios API.
User authentication via Google Login.
Setup and Installation
Prerequisites
Ensure you have the following tools installed on your machine:

.NET 9 SDK
SQL Server (or any compatible database)
Install Dependencies
To install the required packages, run the following commands:
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Scalar.AspNetCore
dotnet add package Microsoft.AspNetCore.OpenApi

Configuration
Configure your SQL Server connection in appsettings.json:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=your-database;Trusted_Connection=True;"
  }
}

Setup the Google Login authentication in Startup.cs or Program.cs:

services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "your-client-id";
        options.ClientSecret = "your-client-secret";
    });

Running the Application
To run the application locally, execute:

dotnet run

The API should be accessible at http://localhost:5000.

Conclusion
This system is a small project aimed at improving skills in .NET 9, Entity Framework, API development, and user authentication. The next steps include adding more features and expanding the functionality.

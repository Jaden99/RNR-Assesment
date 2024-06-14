# RNR-Assesment

# Breakdown Management Application

This is a basic web application for managing vehicle breakdowns. The application allows users to create, update, and list breakdowns. It uses a SQL Server database for data storage, a C# Web API backend, and a React frontend.
Projects are on branch backend and branch frontend

## Features

1. **Create a new Breakdown**
2. **Update a Breakdown**
3. **List Breakdowns**

## Data Model

- **Breakdown Reference**: Unique String
- **Company Name**: String
- **Driver Name**: String
- **Registration Number**: String
- **Breakdown Date**: DateTime

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js and npm](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [MySQL](https://dev.mysql.com/downloads/)

## Setup

### Database

1. Create a database named `BreakdownDB`.
2. Run the following SQL script to create the `Breakdowns` table:

   ```sql
   CREATE TABLE Breakdowns (
       BreakdownReference NVARCHAR(50) PRIMARY KEY,
       CompanyName NVARCHAR(100),
       DriverName NVARCHAR(100),
       RegistrationNumber NVARCHAR(50),
       BreakdownDate DATETIME
   );

### BackEnd
**Update appsettings.json with your database connection string:**

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=BreakdownDB;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

**Run the migrations to create the database schema:**
dotnet ef migrations add InitialCreate
dotnet ef database update

Run the application

### FrontEnd
Frontend (React)
Navigate to the frontend directory.

Install the necessary packages:
npm install

Update the API endpoints in App.jsx if necessary:
axios.get('http://localhost:5000/api/breakdowns');


Run the application




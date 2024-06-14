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

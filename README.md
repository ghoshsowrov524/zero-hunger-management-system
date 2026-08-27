# Zero Hunger Management System

A RESTful ASP.NET Core Web API developed to manage food collection and distribution between restaurants, NGO employees, and beneficiaries. The system helps organize food collection requests and track their progress from collection to distribution.

## Features

* Restaurant management
* Employee management
* Food item management
* Food collection request management
* View pending collection requests
* Assign employees to collection requests
* Update collection request status
* Track completed collection requests
* Food distribution management

## Technologies Used

* C#
* ASP.NET Core Web API
* .NET
* Entity Framework Core
* SQL Server
* AutoMapper
* Postman

## Architecture

The project follows a **3-Tier Architecture**:

* **Presentation Layer** – Handles API requests through Controllers.
* **Business Logic Layer (BLL)** – Contains business logic and Services.
* **Data Access Layer (DAL)** – Handles database operations using Repository Pattern and Entity Framework Core.

## System Workflow

```text
Client
   ↓
Controller
   ↓
Service
   ↓
Repository
   ↓
SQL Server Database
```

The Controller receives the HTTP request and sends it to the Service layer. The Service handles the business logic and communicates with the Repository. The Repository performs database operations using Entity Framework Core.

## Project Structure

```text
ZeroHungerProject/
│
├── ZeroHunger/              # Presentation / API Layer
│   └── Controllers/
│
├── BLL/                     # Business Logic Layer
│   ├── Models/
│   └── Services/
│
├── DAL/                     # Data Access Layer
│   ├── EF/
│   └── Repository/
│
├── postman/                 # Postman API collection
│
├── README.md
└── ZeroHungerProject.slnx
```

## API Operations

The API provides operations for managing:

* Restaurants
* Employees
* Food Items
* Collect Requests
* Food Distribution

Collection requests can be created, retrieved, assigned to employees, and marked as completed according to the workflow of the system.

## Database

The application uses **SQL Server** as the database and **Entity Framework Core** for database access.

The database contains entities related to restaurants, employees, food items, collection requests, and distribution.


The API endpoints can be tested using **Postman**.

The Postman collection included in the repository can be used to test the available API operations.

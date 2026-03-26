# UserApp Backend API

## 📌 Overview

**UserApp Backend API** is a RESTful web service built using **.NET 8 Web API** following **Clean Architecture principles**.
The application provides a scalable and maintainable structure for managing users with features like:

* 🔍 Search users by **name or email**
* 🔄 Filter users by **active/inactive status**
* 📄 Pagination support for efficient data loading

The project demonstrates best practices in:

* Clean Architecture (Separation of Concerns)
* Entity Framework Core (Code-first & Migrations)
* Layered design (API, Application, Infrastructure)

---

## 🏗️ Project Structure

```
UserApp/
│
├── UserApp.API/              # Presentation Layer (Controllers, Startup)
├── UserApp.Application/      # Business Logic (DTOs, Services, Interfaces)
├── UserApp.Infrastructure/   # Data Access (DbContext, EF Core, Repositories)
│
└── UserApp.sln
```

### 🔹 Layer Responsibilities

* **API Layer**

  * Handles HTTP requests
  * Exposes endpoints
  * Configures middleware

* **Application Layer**

  * Contains business logic
  * Defines DTOs and interfaces
  * Keeps domain independent

* **Infrastructure Layer**

  * Handles database operations
  * Implements EF Core DbContext
  * Manages migrations and seeding

---

## 🚀 Features

* ✅ Get paginated list of users
* ✅ Search by name or email
* ✅ Filter by active/inactive status
* ✅ Clean Architecture implementation
* ✅ EF Core migrations for database management

---

## 🔗 API Endpoint

### Get Users

```
GET /api/users
```

### Query Parameters

| Parameter | Type   | Description                  |
| --------- | ------ | ---------------------------- |
| search    | string | Search by name or email      |
| isActive  | bool   | Filter active/inactive users |
| page      | int    | Page number                  |
| pageSize  | int    | Number of records per page   |

---

## 🛠️ Technologies Used

* .NET 8 Web API
* Entity Framework Core
* PostgreSQL (or compatible DB)
* Clean Architecture
* LINQ & ADO.NET (for optimized queries)

---

## ⚙️ Getting Started

### 📥 Clone the Repository

```bash
git clone https://github.com/your-username/User_list_app_web_api.git
cd User_list_app_web_api
```

---

## ▶️ Run the Project

### Step 1: Restore dependencies

```bash
dotnet restore
```

---

### Step 2: Update Database (Run Migrations)

```bash
dotnet ef database update -p UserApp.Infrastructure -s UserApp.API
```

---

### Step 3: Run the API

```bash
dotnet run --project UserApp.API
```

---

### Step 4: Access API

```
https://localhost:5001/api/users
```

---

## 🗄️ Database Migrations

### ➕ Add New Migration

```bash
dotnet ef migrations add MigrationName -p UserApp.Infrastructure -s UserApp.API
```

---

### ⬆️ Apply Migration

```bash
dotnet ef database update -p UserApp.Infrastructure -s UserApp.API
```

---

### ❌ Remove Last Migration

```bash
dotnet ef migrations remove -p UserApp.Infrastructure -s UserApp.API
```

---

## 🌱 Data Seeding

The application uses **runtime seeding** instead of EF Core `HasData`.
Initial user data is inserted when the application starts if the database is empty.

---

## 📌 Notes

* Ensure PostgreSQL (or your configured DB) is running
* Update connection string in `appsettings.json`
* Use `.gitignore` to avoid committing unnecessary files

---

## 📈 Future Improvements

* Add authentication & authorization
* Implement role-based access control
* Add caching (Redis)
* Enhance search with full-text indexing

---

## 👨‍💻 Author

**Md Mahbub Alam**
Software Engineer | Full-Stack Developer

---

## ⭐ Summary

This project demonstrates how to build a **scalable, maintainable backend system** using:

* Clean Architecture
* EF Core migrations
* Efficient querying and filtering

---

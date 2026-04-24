# 🚀 TaskFlow API

A clean, scalable **ASP.NET Core Web API** built to demonstrate best practices in backend development, architecture, and testing.

---

## 🧰 Tech Stack

* **Backend:** C#, .NET / ASP.NET Core Web API
* **Data Access:** Entity Framework Core, SQL Server
* **Querying:** LINQ
* **Validation & Mapping:** FluentValidation, AutoMapper
* **API Docs:** Swagger / OpenAPI

---

## 🧱 Architecture

This project follows a **Layered Architecture**:

* Controllers → handle HTTP requests
* Services → contain business logic
* Repositories → manage data access
* DTOs → control data transfer
* Domain Models → represent core entities

### Patterns Used

* Repository Pattern
* Service Pattern
* Dependency Injection
* DTO Pattern
* Unit of Work (optional, EF Core handles transactions)

---

## 🧪 Testing

* **Framework:** xUnit
* **Mocking:** Moq
* **Database Testing:** EF Core InMemory / SQLite

Focus is on testing:

* Business logic (Services)
* API behavior (Controllers)

---

## 🧠 Principles Applied

### OOP

* Encapsulation
* Abstraction
* Inheritance
* Polymorphism

### SOLID

* Single Responsibility Principle
* Open/Closed Principle
* Liskov Substitution Principle
* Interface Segregation Principle
* Dependency Inversion Principle

### Clean Code

* DRY (Don’t Repeat Yourself)
* KISS (Keep It Simple)
* YAGNI (You Aren’t Gonna Need It)
* Separation of Concerns
* Clear naming and small methods
* Consistent error handling

---

## 🧠 Design Decisions

* Service layer isolates business logic from controllers
* Repository pattern improves testability and separation of concerns
* DTOs prevent exposing internal domain models
* EF Core is used as ORM, leveraging DbContext as Unit of Work

---

## 🛠 Tools

* Visual Studio
* Git / GitHub
* SQL Server Management Studio
* Postman
* Swagger UI

---

## 📌 Goal

This project is designed as a **portfolio-ready API** that demonstrates:

* Clean architecture thinking
* Real-world backend practices
* Testable and maintainable code

---

## 📁 Project Structure

```txt
TaskFlow
├── src
│   └── TaskFlow.API
│       ├── Common
│       ├── Controllers
│       ├── Data
│       ├── Domain
│       │   └── Entities
│       ├── DTOs
│       ├── Helpers
│       ├── Mappings
│       ├── Middlewares
│       ├── Repositories
│       │   ├── Interfaces
│       │   └── Implementations
│       ├── Services
│       │   ├── Interfaces
│       │   └── Implementations
│       ├── Program.cs
│       └── appsettings.json
│
├── tests
│   └── TaskFlow.API.Tests
│       ├── Controllers
│       ├── Services
│       ├── Repositories
│       └── Helpers
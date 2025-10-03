# 🚀 School Project - Complete API for School Management

Welcome to **School**!  
This project was developed as part of the *Internal Talent* challenge and aims to present a robust, modern, and well-structured API for CRUD operations of school entities.  
Here you will find real examples of best practices in software architecture, object-oriented programming, design patterns, continuous integration, and much more! 😎

---

## ✨ Main Features

- Complete **RESTful API** for managing school entities (CRUD 📝).
- Uses **SQL Server database** via Docker for easy setup and portability.
- **Interactive documentation** with Swagger.
- **Unit tests** to ensure quality and reliability of features.
- **Continuous integration** with GitHub Actions for automated builds.
- Versioned and organized code following industry best practices.
- Use of **Conventional Commits** for commit standardization.
- Implementation of **design patterns** (Facade, Strategy, Singleton).
- Example of the four pillars of **Object-Oriented Programming** (OOP).
- **Object relationships** (1:1, 1:n, n:n) using ORM.

---

## 🚦 Requirements

- [.NET 6+](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- SQL Server Client (Management Studio, Azure Data Studio, DBeaver, etc.)

---

## 🐳 Starting the Database with Docker

Run the command below in PowerShell to create a local SQL Server container:

```bash
docker run `
-e "ACCEPT_EULA=Y" `
-e "SA_PASSWORD=Bruno@123" `
-e MSSQL_PID=Developer `
-p 1433:1433 `
-d mcr.microsoft.com/mssql/server:2022-latest
```

Suggested connection:

```bash
Server Name: localhost,1433
Authentication: SQL Server Authentication
User Name: sa
Password: Bruno@123
```

---

## ⚡ Database Migrations

After starting the database, run the migrations to create/update the tables:

```bash
dotnet ef migrations add alterStudent --project .\src\School.API\
dotnet ef database update --project .\src\School.API\
```

---

## 🧑‍💻 Padrões de Projeto Utilizados

- **Facade** *(Estrutural)*: Centraliza e esconde subsistemas do cliente, simplificando o uso de funcionalidades complexas.
- **Strategy** *(Comportamental)*: Permite selecionar dinamicamente algoritmos ou comportamentos em tempo de execução.
- **Singleton** *(Criacional)*: Garante que uma classe tenha apenas uma instância, fornecendo um ponto global de acesso.

## 🧑‍💻 Design Patterns Used
- **Facade** *(Structural)*: Centralizes and hides subsystems from the client, simplifying the use of complex features.
- **Strategy** *(Behavioral)*: Allows dynamic selection of algorithms or behaviors at runtime.
- **Singleton** *(Creational)*: Ensures a class has only one instance, providing a global access point.
---

## 🧩 Object-Oriented Programming (OOP) Pillars

The project demonstrates:
- **Abstraction**
- **Encapsulation**
- **Inheritance**
- **Polymorphism**
---

## 🛠️ ORM
Uses ORM for object-relational mapping and managing relationships between entities (1:1, 1:n, n:n), making queries and code maintenance easier.

---

## 🧪 Unit Tests

> **Highlight!**  
> The project contains unit tests to ensure the quality and robustness of the main features!
> Run the tests with the command:

```bash
dotnet test
```

Make sure everything is working before pushing your changes! ✅

---

## 📖 Swagger Documentation

Access the interactive documentation at: `http://localhost:<porta>/swagger`

Explore and test the API endpoints directly from your browser!
---

## 🔄 Continuous Integration

This project uses **GitHub Actions** for automatic build and test execution on every commit, ensuring continuous quality!
Check the build status directly in the repository

---

## 📋 Requirements Checklist
- [x] Complete CRUD
- [x] Use of primitive types (int, bool, datetime, string, array)
- [x] 1 example of each OOP pillar
- [x] 1 example of Design Pattern (creational, behavioral, structural)
- [x] Object relationships
- [x] ORM
- [x] Unit tests
- [x] Swagger
- [x] Detailed README.md
- [x] Versioned code on GitHub
- [x] Buil with GitHub Actions
- [x] Conventional Commits
---

## 💡 How to Contribute

Feel free to submit PRs, open issues, suggest improvements, or report bugs.
Let's build an even better project together! 🤝✨

# Medical Reports API

A RESTful API built with .NET and SQL Server that combines client medical data with guidelines to generate comprehensive medical reports.

## Prerequisites

- [Docker](https://www.docker.com/get-started) and Docker Compose

## Quick Start

1. **Configure environment**
   Linux/Mac:
```bash
   cp .env.example .env
```
   
   Windows:
```bash
   copy .env.example .env
```
   
   Edit `.env` and set your database password.

2. **Run the application**
```bash
   docker-compose up -d
```

3. **Access the API**
   - API: http://localhost:8001
   - Swagger: http://localhost:8001/swagger

## Stop the Application
```bash
docker-compose down
```

## Technology Stack
- **Backend:** ASP.NET Core Web API
- **Database:** Microsoft SQL Server
- **Architecture:** Clean Architecture (API, Application, Core, Infrastructure layers)
- **Deployment:** Docker & Docker Compose
- **Testing:** MSTest

---

# **Niped Challenge**

In the Data folder of this repository you will find two JSON files, medical guidelines and client medical data with values that are referenced in the guidelines.

**Create a system to return a report for the given clients by combining their medical data with the guidelines.**

There is a lot of freedom in this exercise where you can choose which parts of the application you find most important and we are not looking for one specific solution. You can make it an API, webapplication, native app. Do you include security issues, and if so how? Will you create a backend system to handle the configuration of the guidelines? It's all up to you. You are also free the change the data structure of the given JSON files, either in the files or while processing/storing/handling it later in the application.

Use whatever technologies you want to show off. At Niped we use C# and MSSql on the Azure platform with communication between services through Azure ServiceBus. But do you prefer creating a web application, or native apps with Flutter and a SignalR or Python-based API, or even a WebAssembly web application? Go for it. We believe good developers can adapt to whatever technology they are interested in.

We are not expecting you to create a fully-fledged health check application, so choose wisely which parts of such a solution you want to focus on. Create what you feel shows off your programming skills best and then send in a Pull Request. You will then be invited for an interview with two Developers in which you can discuss your choices with them.

Good luck, and most importantly, have fun!

#### **Evaluation Criteria**
- Code structure, readability, testability and maintainability.
- Database design choices.
- Bonus: Security best practices and scalability considerations.

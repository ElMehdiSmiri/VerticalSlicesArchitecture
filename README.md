# Vertical Slices Architecture: C# Starter Kit

## Overview

This application serves as a comprehensive starting point for your C# development projects. It is built using C# 8 and incorporates several important architectural patterns and libraries, including MediatR, Vertical Slices Architecture, Domain-Driven Design (DDD), Logging, Domain Events, and Validation with Fluent Validation. This README provides an overview of the application structure, features, and how to get started with your development journey.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Getting Started](#getting-started)
3. [Application Structure](#application-structure)
4. [Features](#features)
5. [Dependencies](#dependencies)
6. [Contributing](#contributing)
7. [License](#license)

## Prerequisites

Before you can start using this starter kit, make sure you have the following prerequisites installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- An SQL server instance
- Your preferred code editor (e.g., Visual Studio, Visual Studio Code)

## Getting Started

To get started with the C# Starter Kit, follow these steps:

1. Clone this repository to your local machine:
```
git clone https://github.com/ElMehdiSmiri/VerticalSlicesArchitecture
```
2. Navigate to the project directory:
```
cd VerticalSlicesArchitecture
```
3. Build the solution:
```
dotnet build
```
4. Run the application:
```
dotnet run
```
Now, your application should be up and running. You can access it in your web browser at `http://localhost:7295`.
## SQL Entity Framework Code First

The C# Starter Kit uses SQL Entity Framework Code First to manage its database schema. Here's how to set up and apply migrations:

1. **Database Connection**: Open the `appsettings.json` file in the `App/Api` folder and configure your database connection string. Replace `<your-connection-string>` with your actual database connection string.

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=<your-server>;Database=<your-database>;User Id=<your-username>;Password=<your-password>;"
   }
2. Apply Migrations: To create and apply the initial database schema, run the following commands:
  ```
  cd VerticalSlicesArchitecture
  dotnet ef migrations add InitialMigration --project App.Infrastructure -s App.Api
  dotnet ef database update --project App.Infrastructure -s App.Api
  ```
3. Update the Database: Whenever you make changes to the domain models or data structures, create a new migration and apply it:
  ```
  dotnet ef migrations add YourMigrationName --project App.Infrastructure -s App.Api
  dotnet ef database update --project App.Infrastructure -s App.Api
  ```
## Application Structure

The C# Starter Kit follows a modular and organized structure that promotes maintainability and scalability. Here is a brief overview of the key components:

- **App/Api**: This directory contains the REST endpoints

- **App/Application**: This folder houses the application's use cases, also known as "vertical slices." Each use case is organized in a separate folder and contains commands, handlers, and validation logic.

- **App/Domain**: This directory contains the domain entities, aggregates, and domain events.

- **App/Infrastructure**: Here, you'll find infrastructure-related code such as database configuration, migrations, and external service integrations.

- **App/test**: This directory contains unit tests and integration tests to ensure the application's reliability and correctness.

## Features

The C# Starter Kit comes with several features and integrations that you can leverage in your projects:

- **MediatR**: Utilizes the MediatR library for handling requests and commands.

- **Vertical Slices Architecture**: Promotes organized code by grouping related features together.

- **Domain-Driven Design (DDD)**: Encourages modeling your application based on the domain's needs and complexity.

- **Logging**: Implements a robust logging system for tracking application events and errors.

- **Domain Events**: Supports domain events to decouple components and trigger actions based on specific events.

- **Validation with Fluent Validation**: Ensures that incoming data meets the required criteria using Fluent Validation.

## Dependencies

The C# Starter Kit relies on the following libraries and packages:

- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://fluentvalidation.net/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- [xUnit](https://xunit.net/)

For a complete list of dependencies and their versions, please refer to the `*.csproj` files in the respective project folders.

## Contributing

Contributions are welcome. If you'd like to contribute, please follow these guidelines:

1. Fork the repository and create a feature branch.
2. Make your changes and ensure that all tests pass.
3. Create a pull request with a clear description of your changes.

## License

The C# Starter Kit is open-source and available under the [MIT License](LICENSE). Feel free to use it for your projects and customize it as needed.

---

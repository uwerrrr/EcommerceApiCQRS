# EcommerceApiCQRS

This is a sample **Product Management System** project built using the **CQRS (Command Query Responsibility Segregation)** pattern in **.NET**. The project demonstrates how to structure a solution to separate read and write operations effectively, enhancing scalability, maintainability, and performance.

## Project Overview

The EcommerceApi project manages products by separating read and write operations through the CQRS pattern. This approach splits the logic for handling commands (create, update, delete) and queries (read) into distinct parts, allowing for optimized operations in each area.

### Key Concepts

- **CQRS Pattern**: Divides the application into two distinct parts—Commands and Queries.
  - **Commands**: Responsible for write operations (create, update, delete).
  - **Queries**: Responsible for read operations (retrieving data).
- **.NET 8**: Built with .NET 8, using C# for business logic, data access, and API.
- **Entity Framework Core**: Manages data persistence for products.

## Project Structure

The project is organized into four main projects within the solution:

### 1. Application

Contains business logic for handling commands and queries.

- **Commands**: Classes and handlers for writing data (e.g., creating or updating a product).
- **Queries**: Classes and handlers for reading data (e.g., retrieving product information).
- **DTOs (Data Transfer Objects)**: Define the shape of data sent to clients, ensuring separation from core domain entities.
- **Mappings**: Maps domain entities to DTOs, facilitating structured responses for API clients.

### 2. Domain

Defines core business entities and interfaces.

- **Entities**: Core data structures like `Product`.
- **Interfaces**: Define contracts for data access (e.g., `IProductRepository`), ensuring that application logic is decoupled from data storage.

### 3. Infrastructure

Implements data access and storage.

- **Repositories**: Implement interfaces to handle data access logic (e.g., `ProductRepository`).
- **Persistence**: Configures `AppDbContext` for Entity Framework Core, connecting to the database.

### 4. Web

Exposes APIs for interacting with the product management system.

- **Controllers**: API endpoints for command and query operations, following RESTful principles.
- **Configuration Files**: Includes `appsettings.json` for environment configuration and `Program.cs` for application setup.

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server (or any database configured in `appsettings.json`)

### Setup and Run

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repository-url
   ```
2. Navigate to the project directory and restore dependencies:
   ```bash
   dotnet restore
   ```
3. Update the database configuration in `appsettings.json` (if needed).
4. Run migrations to set up the database:
   ```bash
   dotnet ef database update
   ```
5. Start the API:
   ```bash
   dotnet run --project Web
   ```

### Endpoints

- **Create Product**: `POST /api/products` (Command)
- **Get Product by ID**: `GET /api/products/{id}` (Query)
- **Get All Products**: `GET /api/products` (Query)
- **Update Product**: `PUT /api/products/{id}` (Command)
- **Delete Product**: `DELETE /api/products/{id}` (Command)

## Contributing

Contributions are welcome! Please fork the repository and make a pull request.

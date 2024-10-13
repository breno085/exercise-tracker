# Exercise Tracker

## Project Overview

This project is built with .NET C#, using Entity Framework and SQLite, focusing on managing exercises and tracking user inputs for exercise duration.

## Key Concepts and Explanations for Reference Later

### 1. Use of Interfaces
In this application, I created interfaces to define contracts for various components, such as repositories and services. The primary functions of these interfaces include:

- **Decoupling**: Interfaces help decouple the implementation from the usage, meaning that the rest of the application relies on the interface, not the specific implementation.
- **Testability**: Using interfaces allows for easier unit testing, as mock implementations can be created for testing without needing a real database connection (I can use a mock framework or create a mock repository for tests).
- **Flexibility**: By programming against interfaces, I can easily switch implementations if necessary, which is especially useful in larger applications.

### 2. Repository Pattern - Generic vs. Specific Interfaces and Repositories
- **Generic Repository**: A generic repository uses a generic interface and class to handle CRUD operations for multiple entities. This is beneficial when there are multiple service classes performing similar operations, allowing for code reuse. While I implemented a specific interface and repository in this project, the generic implementation can be found in the following articles:
  - [Repository Pattern Docs](https://medium.com/@kerimkkara/implementing-the-repository-pattern-in-c-and-net-5fdd91950485)
  - [Repository Pattern Tutorial](https://programmingwithwolfgang.com/repository-pattern-net-core/)

- **Mock Classes**: A mock class simulates database operations without connecting to a real database. This is particularly useful for unit tests, allowing for isolated testing of service methods without external dependencies. (I could use a mock framework instead of creating a mock class for the repository.)

### 3. Understanding Class Responsibilities
- **Controllers**: In this project, the controller serves as an intermediary between the user input and the service classes. It retrieves input from the `UserInput` class and passes it to the corresponding service, which contains business logic such as validating data or calculating exercise duration.
  
  *Note*: The behavior of controllers may differ in API projects, where they handle HTTP requests and responses directly.

- **Repositories**: These classes handle data access and CRUD operations for specific entities.

- **Services**: Service classes contain the business logic and coordinate between controllers and repositories.

### 4. User Input
The `UserInput` class handles user input and displays information to the user. It can include logic for validating user inputs before passing the information to the controller. However, additional business logic should be left to the service classes.

### 5. Dependency Injection
Dependency injection is a design pattern used to manage dependencies between classes (dependencies are objects that need other objects to perform their methods). Instead of creating dependencies manually, a container is used to resolve and inject them automatically. This enhances testability and maintainability. In this project, dependency injection is configured in `Program.cs`, allowing services and repositories to be easily swapped or mocked during testing.

### 6. Separation of Concerns
This project is designed for user interaction rather than as a web API. If an API were to be created, a separate project would handle all API-related functionality, while this project would focus solely on user interaction. This follows the principle of separation of concerns, promoting cleaner architecture. The context and service classes may remain similar across both projects, but as they evolve, the differences in implementation may grow.

## Conclusion
This project incorporates various design principles, such as interfaces, dependency injection, and the repository pattern, to create a clean and maintainable codebase. It serves as a solid foundation for managing exercise tracking and user interactions.
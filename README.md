# exercise-tracker

Things i need to write here to consult later:
1 - Explain why i create interfaces in this app and its funcions 
2 - Explain the diference of creating an generic interface with and generic repository class and an specifc one (with the links the see the generic implementation) (need to understand the mock class, that is a class that simulates the database operation without conecting to the real database, that is one of the reasons to use and interface - create one in this project and an example) (you create with the generic interface and repository class when you have multiple services classes in your project that would do the exacly crud operations using and ORM like Entity Framework, but in a real aplication you could have diferent crud operations or even the same but using Dapper or raw SQL, so it would be better to have more specific classes, i 2would that later in this project)
3 - The the diference of controller, repositories, services, etc class (OBS: The Controller works
diferently when the project have an API and don't have one. In this project the controller
just take the user input from the UserInput class and send it to the service class that contains the business logic like calculate exercise duration, validating data or other complex configuration. Also you can use the controller for tests before)
4 - Understand Dependency Injection (The dependencies are objects that need other objets to perform its methods, you don't do this manually you create and container that handle this in the Program.cs)
5 - This project is not an web API project, if i would want to be, i would create another project more specific that handle all the API stuff, and leave this one just for the user interaction, so i'm following the principle of separation of concerns. I think first the Context and the Service classe would be almost or even the same in both projects, but as the project grows thinks would be more diferent.

Chatgpt links:
Explaning of Repository Pattern, Intercaces, DI, Mock classes, etc - https://chatgpt.com/c/670bcc43-5b60-800f-ad09-747ec380ace6
Repository vs Controller in C# - https://chatgpt.com/c/6703f654-468c-800f-8d9e-61a7aa7fb520


I also need to do all the challenges in this project, so i can have a more complete project.
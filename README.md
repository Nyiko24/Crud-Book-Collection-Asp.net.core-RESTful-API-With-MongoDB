# Crud-Book-Collection-Asp.net.core-RESTful-API-With-MongoDB

 I've created a RESTful API using C# that allows users to manage a collection of books. The API uses the API server and a MongoDB database, making it easy to set up and run locally on any Windows machine.

Things I did:

Using  C# and ASP.NET Core to develop the RESTful API.
1. Implemented CRUD (Create, Read, Update, Delete) operations for books. Each book should have the following properties:
Title (string, required).
Author (string, required).
Genre (string, optional).
Publication Year (integer, optional).
ISBN (string, unique, optional).

2. Created API endpoints for the following actions:
¬ Create a new book.
¬  Retrieve a book by its ISBN.
¬  Update an existing book by its ISBN.
¬  Delete a book by its ISBN.
¬  List all books.

3. Implemented input validation to ensure that required fields are provided and that ISBNs are unique.
4. Implemented proper error handling and return appropriate HTTP status codes and error messages.
5. Used proper RESTful API conventions for endpoint naming and HTTP methods.
6. Used MongoDB as the database to store and retrieve book data.

Before you run this project. Make sure you add your mongoDB connectionString under the file of appsettings.json for it to run successfully. As I have indicate on the picture below

![image](https://github.com/Nyiko24/Crud-Book-Collection-Asp.net.core-RESTful-API-With-MongoDB/assets/114064061/af5d4333-706c-419e-a5ca-2c79020fd712)


8. When you run the project. This is what will appear. Which you see 5 API endpoints.

![image](https://github.com/Nyiko24/Crud-Book-Collection-Asp.net.core-RESTful-API-With-MongoDB/assets/114064061/8d6085b0-c641-4544-a2fd-ed827662b761)



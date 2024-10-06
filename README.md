<h1 align="center" style="font-weight: bold;">Simply Books Minimal APIs</h1>

<p align="center">
    <b>A small collection of minimal APIs using the Repository Pattern.  It has a one to many relationship between Authours and books. </b>
</p>

<h2 id="technologies">Technologies</h2>

 Technologies used include :
- C#
- .Net
- SQL
- EF core
- AutoMapper - for object mapping
- Swagger and Postman were used for testing, and documentation
  
  Postman publication : https://documenter.getpostman.com/view/32010448/2sAXxMgtry

<h2 id="started">Getting started</h2>

<h3>Prerequisites</h3>

Here are a list of packages necessary for running the project:

- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0
- dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0
- dotnet add package AutoMapper

<h3>Cloning</h3>

```bash
git clone https://github.com/Mrthincrisp/SimplyBooks-BE.git
```

<h2 id="routes">Endpoints</h2>

The Endpoints you will find here are:
​
| route (author)              | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /User authors</kbd>     | retrieves user authors 
| <kbd>GET /Single author</kbd>     | retrieves a single auuthor data 
| <kbd>DELETE /An author</kbd>     | Delete an author, and thier respective books 
| <kbd>PUT /An author</kbd>     | Edit an author's data
| <kbd>Post /An author authors</kbd>     | Create a new author 
| <kbd>GET /Favorite author</kbd>     | Retrieves a user's favorite authors 
| <kbd>PATCH /Author favorite</kbd>     | A toggle for the author bool favorite 

| route (book)              | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /User bookss</kbd>     | retrieves user books
| <kbd>GET /Single book</kbd>     | retrieves a single book's data 
| <kbd>DELETE /A Book</kbd>     | Delete a book, not the author 
| <kbd>PUT /A book</kbd>     | Edit a book's data
| <kbd>Post /A Book</kbd>     | Create a new book 

More in depth documentaion available at: https://documenter.getpostman.com/view/32010448/2sAXxMgtry

using SimplyBooks.Models;
using SimplyBooks.Interface;
using AutoMapper;
using SimplyBooks.DTOs;
using System.ComponentModel.DataAnnotations;
namespace SimplyBooks.Endpoints
{
    public static class BookEndpoints
    {
        public static void MapBookEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/book").WithTags(nameof(Book));

            //GET a user's books
            group.MapGet("/user/{id}", async (IBookService book, int id) =>
            {
                var userBook = await book.GetUserBookAsync(id);

                if (userBook == null)
                {
                    return Results.Problem("Error retrieving books for the user. Please try again, or there is an internal server error.");
                }

                if (userBook.Count == 0)
                {
                    return Results.NotFound("No books found for the specified user.");

                }

                return Results.Ok(userBook);
            })
                .WithName("GetUserBooks")
                .WithOpenApi()
                .Produces<List<Book>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);

            //GET a single Book
            group.MapGet("{id}", async (IBookService book, int id) =>
            {
                var singleBook = await book.GetBookByIdAsync(id);
                
                if (singleBook == null)
                {
                    return Results.NotFound("Book not found");
                }

                return Results.Ok(singleBook);

            })
                .WithName("GetSingleBook")
                .WithOpenApi()
                .Produces<Book>(StatusCodes.Status200OK);

            //POST a book
            group.MapPost("/", async (IBookService book, BookCreateDTO bookCreateDTO, IMapper mapper) =>
            {
                var createdBook = await book.CreateBookAsync(bookCreateDTO, mapper);

                if (createdBook == null)
                {
                    return Results.BadRequest("Unable to create book");
                }

                return Results.Created($"/book/{createdBook.Id}", createdBook);
            })
                .WithName("CreatedBook")
                .WithOpenApi()
                .Produces<Book>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            //PUT a book
            group.MapPut("/{id}", async (IBookService bookService, int id, IMapper mapper, BookEditDTO bookEditDTO) =>
            {
                // Validate the DTO
                var validationResults = new List<ValidationResult>(); // creates empty list to place potential error list
                var validationContext = new ValidationContext(bookEditDTO); // grabrs required keys from DTO to compare in next line
                bool isValid = Validator.TryValidateObject(bookEditDTO, validationContext, validationResults, true); //compares data to DTO, failures send errors to results list

                if (!isValid)
                {
                    return Results.BadRequest(validationResults.Select(v => v.ErrorMessage)); // returns the reult list to the user
                }

                var editedBook = await bookService.UpdateBookAsync(id, mapper, bookEditDTO);

                if (editedBook == null)
                {
                    return Results.NotFound("Book not found.");
                }

                return Results.Ok(editedBook);
            })
            .WithName("EditBook")
            .WithOpenApi()
            .Produces<Book>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

            //DELETE a book
            group.MapDelete("/{id}", async (IBookService book, int id) =>
            {

                var deletedBook = await book.DeleteBookAsync(id);

                if (deletedBook == null)
                {
                    return Results.NotFound("No book found");
                }

                return Results.Ok("Book deleted");

            })
                .WithName("DeleteBook")
                .WithOpenApi()
                .Produces<Book>(StatusCodes.Status204NoContent);

        }
    }
}

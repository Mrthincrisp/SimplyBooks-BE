using SimplyBooks.Models;
using SimplyBooks.Interface;
using AutoMapper;
using SimplyBooks.DTOs;
using System.ComponentModel.DataAnnotations;
namespace SimplyBooks.Endpoints
{
    public static class AuthorEndpoints
    {
        public static void MapAuthorEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/author").WithTags(nameof(Author));
            
            //GET a user's authors
            group.MapGet("/user/{id}", async (IAuthorService author, int id) =>
            {   
                var userAuthor = await author.GetAuthorByUserAsync(id);

                if (userAuthor == null)
                {
                    return Results.Problem("Error retrieving authors for the user. Please try again, or there is an internal server error.");
                }

                if (userAuthor.Count == 0)
                {
                    return Results.NotFound("No authors found for the specified user.");
                }

                return Results.Ok(userAuthor);
            })
                .WithName("GetUserAuthors")
                .WithOpenApi()
                .Produces<List<Author>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);

            //GET a single Author
            group.MapGet("/{id}", async (IAuthorService author, int id) =>
            {
                var singleAuthor = await author.GetAuthorByIdAsync(id);

                if (singleAuthor == null)
                {
                    return Results.NotFound("No author found");
                }

                return Results.Ok(singleAuthor);
            })
            .WithName("Author")
            .WithOpenApi()
            .Produces<Author>(StatusCodes.Status200OK);

            //GET a users favorite author
            group.MapGet("/favorite/{id}", async (IAuthorService author, int id) =>
            {
                var favoriteAuthor = await author.GetUserFavoriteAuthorAsync(id);
                if (favoriteAuthor == null)
                {
                    return Results.NotFound("No athours found");
                }

                return Results.Ok(favoriteAuthor);
            })
            .WithName("FavoriteAuthors")
            .WithOpenApi()
            .Produces<List<Author>>(StatusCodes.Status200OK);

            //DELETE an Author
            group.MapDelete("/{id}", async (IAuthorService author, int id) =>
            {
                var authorToDelete = await author.DeleteAuthorAsync(id);

                if (authorToDelete == null)
                {
                    return Results.NotFound("No author found");
                }

                return Results.Ok("Author, and related books deleted.");
            })
            .WithName("Delete Author")
            .WithOpenApi()
            .Produces<Author>(StatusCodes.Status204NoContent);

            // Edit(PUT) an Author
            group.MapPut("/{id}", async (IAuthorService iAuthor, int id, IMapper mapper, AuthorEditDTO authorEditDTO) =>
            {

                // Validate the DTO
                var validationResults = new List<ValidationResult>(); // creates empty list to place potential error list
                var validationContext = new ValidationContext(authorEditDTO); // grabrs required keys from DTO to compare in next line
                bool isValid = Validator.TryValidateObject(authorEditDTO, validationContext, validationResults, true); //compares data to DTO, failures send errors to results list

                if (!isValid)
                {
                    return Results.BadRequest(validationResults.Select(v => v.ErrorMessage)); // returns the reult list to the user
                }

                var authorUpdate = await iAuthor.UpdateAuthorAsync(id, mapper, authorEditDTO);

                if (authorUpdate == null)
                {

                    return Results.BadRequest("Unable to create author");
                }


                return Results.Created($"/author/{authorUpdate.Id}", authorUpdate);
            })
            .WithName("UpdateAuthor")
            .WithOpenApi()
            .Produces<Author>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status204NoContent);

            // POST an Author
            group.MapPost("/", async (IAuthorService iAuthor, IMapper mapper, AuthorCreateDTO authorCreateDTO) =>
            {
                var createdAuthor = await iAuthor.CreateAuthorAsync(authorCreateDTO, mapper);

                if (createdAuthor == null)
                {
                    
                    return Results.BadRequest("Unable to create author");
                }

                
                return Results.Created($"/authors/{createdAuthor.Id}", createdAuthor);
            })
            .WithName("CreateAuthor")
            .WithOpenApi()
            .Produces<Author>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            //PATCH an author's favorite status
            group.MapPatch("/favorite/{id}", async (IAuthorService author, int id) =>
            {
                var editedAuthor = await author.FavoriteAnAuthorAsync(id);

                if (editedAuthor == null)
                {
                    return Results.BadRequest("No author found");
                }

                return Results.Created($"/favorite/{id}", editedAuthor);
            })
            .WithName("FavoriteAuthor")
            .WithOpenApi()
            .Produces<Author>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
        }
    }
}

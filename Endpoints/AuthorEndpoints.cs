using SimplyBooks.Models;
using SimplyBooks.Interface;
using AutoMapper;
using SimplyBooks.DTOs;
namespace SimplyBooks.Endpoints
{
    public static class AuthorEndpoints
    {
        public static async void MapAuthorEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Author").WithTags(nameof(Author));
            
            //GET a user's authors
            group.MapGet("/User/{id}", async (IAuthorService author, int id) =>
            {
                var userAuthor = await author.GetAuthorByUserAsync(id);

                if (userAuthor == null)
                {
                    return Results.NotFound("No authors found");
                }

                return Results.Ok(userAuthor);
            })
                .WithName("GetUserAuthors")
                .WithOpenApi()
                .Produces<List<Author>>(StatusCodes.Status200OK);

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

            //DELETE an Author
            group.MapDelete("/{id}", async (IAuthorService author, int id) =>
            {
                var authorToDelete = await author.DeleteAuthorAsync(id);

                if (authorToDelete == null)
                {
                    return Results.NotFound("No author found");
                }

                return Results.Ok("Author deleted.");
            })
            .WithName("Delete Author")
            .WithOpenApi()
            .Produces<Author>(StatusCodes.Status204NoContent);

            // Edit(PUT) an Author
            group.MapPut("/{id}", async (IAuthorService iAuthor, int id, IMapper mapper, AuthorEditDTO authorEditDTO) =>
            {
                var authorUpdate = await iAuthor.UpdateAuthorAsync(id, mapper, authorEditDTO);

                if (authorUpdate == null)
                {

                    return Results.BadRequest("Unable to create author");
                }


                return Results.Created($"/authors/{authorUpdate.Id}", authorUpdate);
            })
            .WithName("UpdateAuthor")
            .WithOpenApi()
            .Produces<Author>(StatusCodes.Status200OK)
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
        }
    }
}

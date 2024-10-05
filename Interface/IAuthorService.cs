using AutoMapper;
using SimplyBooks.DTOs;
using SimplyBooks.Models;
namespace SimplyBooks.Interface
{
    public interface IAuthorService
    {
        // The service layer is responsible for processing business logic.
        // The service layer will call the repository layer to do the actual operations; any call made needs its own Task.

        Task<List<Author>> GetAuthorByUserAsync(int id);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(AuthorCreateDTO authorCreateDTO, IMapper mapper);
        Task<Author> UpdateAuthorAsync(int id, IMapper mapper, AuthorEditDTO authorEditDTO);
        Task<Author> DeleteAuthorAsync(int id);
    }
}

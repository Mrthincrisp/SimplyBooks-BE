using AutoMapper;
using SimplyBooks.DTOs;
using SimplyBooks.Models;

namespace SimplyBooks.Interface
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAuthorByUserAsync(int id);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<List<Author>> GetUserFavoriteAuthorAsync(int id);
        Task<Author> CreateAuthorAsync(AuthorCreateDTO authorCreateDTO, IMapper mapper);
        Task<Author> UpdateAuthorAsync(int id, IMapper mapper, AuthorEditDTO authorEditDTO); // (argument pattern matters for other parts of the pattern)
        Task<Author> DeleteAuthorAsync(int id);
        Task<Author> FavoriteAnAuthorAsync(int id);
    }
}

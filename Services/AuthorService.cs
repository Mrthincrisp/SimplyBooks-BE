using AutoMapper;
using SimplyBooks.DTOs;
using SimplyBooks.Interface;
using SimplyBooks.Models;
namespace SimplyBooks.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<Author> CreateAuthorAsync(AuthorCreateDTO authorCreateDTO, IMapper mapper)
        {
            return await _authorRepo.CreateAuthorAsync(authorCreateDTO, mapper);
        }

        public async Task<List<Author>> GetUserFavoriteAuthorAsync(int id)
        {
            return await _authorRepo.GetUserFavoriteAuthorAsync(id);
        } 

        public async Task<Author> DeleteAuthorAsync(int id)
        {
            return await _authorRepo.DeleteAuthorAsync(id);
        }
        
        public async Task<List<Author>> GetAuthorByUserAsync(int id)
        {
            return await _authorRepo.GetAuthorByUserAsync(id);
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _authorRepo.GetAuthorByIdAsync(id);
        }

        public async Task<Author> UpdateAuthorAsync(int id, IMapper mapper, AuthorEditDTO authorEditDTO)
        {
            return await _authorRepo.UpdateAuthorAsync(id, mapper, authorEditDTO);
        }
    }
}

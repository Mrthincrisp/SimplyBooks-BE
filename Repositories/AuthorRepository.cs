using SimplyBooks.Models;
using SimplyBooks.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SimplyBooks.DTOs;
namespace SimplyBooks.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly SimplyBooksDbContext _context;

        public AuthorRepository(SimplyBooksDbContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> GetAuthorByUserAsync(int id)
        {
            var authors =  await _context.Authors
                .Where(a=> a.UserId == id)
                .ToListAsync();
            if (authors == null)
            {
                return null;
            }
            return authors;
        }
        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = _context.Authors.Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
            if (author == null)
            {
                return null;
            }

            return author;
        }
        public async Task<List<Author>> GetUserFavoriteAuthorAsync(int id)
        {
           return await _context.Authors
                .Where(a => a.UserId == id && a.Favorite == true)
                .ToListAsync();
        }
        public async Task<Author> CreateAuthorAsync(AuthorCreateDTO authorCreateDTO, IMapper mapper)
        {
            var author = mapper.Map<Author>(authorCreateDTO);

            try
            {
                _context.Authors.Add(author); 
                await _context.SaveChangesAsync();
                return author;
            }
            catch (DbUpdateException) 
            {
                return null;
            }
        }
        public async Task<Author> UpdateAuthorAsync(int id, IMapper mapper, AuthorEditDTO authorEditDTO)
        {
            var existingAuthor = await _context.Authors.FindAsync(id);
            if (existingAuthor == null)
            {
                return null; //omg null is possibly null *slow clap* gj VS
            }

            mapper.Map(authorEditDTO, existingAuthor);
            try
            {
                await _context.SaveChangesAsync();
                return existingAuthor;

            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<Author> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if(author == null)
            {
                return null;
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }
        public async Task<Author> FavoriteAnAuthorAsync(int id)
        {
            var existingAuthor = await _context.Authors.FindAsync(id);

            if (existingAuthor == null)
            {
                return null;
            }

            existingAuthor.Favorite = !existingAuthor.Favorite;

            await _context.SaveChangesAsync();
            return existingAuthor;

        }
    }
}

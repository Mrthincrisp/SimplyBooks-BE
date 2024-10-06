using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimplyBooks.DTOs;
using SimplyBooks.Interface;
using SimplyBooks.Models;
namespace SimplyBooks.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SimplyBooksDbContext _context;

        public BookRepository(SimplyBooksDbContext context) {
            _context = context;
        }
        public async Task<List<Book>> GetUserBookAsync(int id)
        {
            return await _context.Books
                .Where(b => b.UserId == id)
                .ToListAsync();
        }
        public async Task<Book> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.Include(a => a.Author)
                .SingleOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return null;
            }

            return book;
        }
        public async Task<Book> CreateBookAsync(BookCreateDTO bookCreateDTO, IMapper mapper)
        {
            var book = mapper.Map<Book>(bookCreateDTO);

            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return book;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<Book> UpdateBookAsync(int id, IMapper mapper, BookEditDTO bookEditDTO)
        {
            var bookToUpdate = await _context.Books.FindAsync(id);

            if (bookToUpdate == null)
            {
                return null;
            }
            mapper.Map(bookEditDTO, bookToUpdate);
            try
            {

                await _context.SaveChangesAsync();
                return bookToUpdate;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
        public async Task<Book> DeleteBookAsync(int id)
        {
            var bookToDelete = await _context.Books.FindAsync(id);
            if (bookToDelete == null)
            {
                return null;
            }
            _context.Books.Remove(bookToDelete);
            await _context.SaveChangesAsync();
            return bookToDelete;
        }
    }
}

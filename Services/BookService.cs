using SimplyBooks.Interface;
using AutoMapper;
using SimplyBooks.DTOs;
using SimplyBooks.Models;
namespace SimplyBooks.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public async Task<List<Book>> GetUserBookAsync(int id)
        {
            return await _bookRepo.GetUserBookAsync(id);
        }
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _bookRepo.GetBookByIdAsync(id);
        }
        public async Task<Book> CreateBookAsync(BookCreateDTO bookCreateDTO, IMapper mapper)
        {
            return await _bookRepo.CreateBookAsync(bookCreateDTO, mapper);
        }
        public async Task<Book> UpdateBookAsync(int id, IMapper mapper, BookEditDTO bookEditDTO)
        {
            return await _bookRepo.UpdateBookAsync(id, mapper, bookEditDTO);
        }
        public async Task<Book> DeleteBookAsync(int id)
        {
            return await _bookRepo.DeleteBookAsync(id);
        }
    }
}

using AutoMapper;
using SimplyBooks.DTOs;
using SimplyBooks.Models;

namespace SimplyBooks.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetUserBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(BookCreateDTO bookCreateDTO, IMapper mapper);
        Task<Book> UpdateBookAsync(int id, IMapper mapper, BookEditDTO bookEditDTO);
        Task<Book> DeleteBookAsync(int id);
    }
}

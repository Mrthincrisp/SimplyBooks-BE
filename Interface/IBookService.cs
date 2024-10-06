using SimplyBooks.Models;
using SimplyBooks.DTOs;
using AutoMapper;
namespace SimplyBooks.Interface
{
    public interface IBookService
    {
        Task<List<Book>> GetUserBookAsync(int id);
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(BookCreateDTO bookCreateDTO, IMapper mapper);
        Task<Book> UpdateBookAsync(int id, IMapper mapper, BookEditDTO bookEditDTO);
        Task<Book> DeleteBookAsync(int id);
    }
}

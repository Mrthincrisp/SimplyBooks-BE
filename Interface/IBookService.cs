using SimplyBooks.Models;
namespace SimplyBooks.Interface
{
    public interface IBookService
    {
        Task<List<Book>> GetBookAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, Book book);
        Task<Book> DeleteBookAsync(int id);
    }
}

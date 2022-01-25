using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Entities;

namespace Library.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);
        
        Task<IEnumerable<Book>> GetBooksAsync();
        
        void Update(Book book);
        
        void DeleteBook(Book book);
        
        Task<Book> GetBook(int id);
    }
}
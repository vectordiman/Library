using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Library.Entities;
using Library.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<Book> AddBookAsync(Book book)
        {
            var entry = await _context.Books.AddAsync(book);
            return entry.Entity;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
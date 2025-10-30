using Application.Interfaces;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApi.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Set<Book>().ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Book>().FindAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            var created = await _dbContext.Set<Book>().AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return created.Entity;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _dbContext.Set<Book>().Update(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var book = await _dbContext.Set<Book>().FindAsync(id);
            if (book == null) return false;
            _dbContext.Set<Book>().Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
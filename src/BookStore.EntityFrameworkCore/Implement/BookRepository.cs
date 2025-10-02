using BookStore.Entities;
using BookStore.EntityFrameworkCore;
using BookStore.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Linq;
using System.Linq.Dynamic.Core;

namespace BookStore.Implement
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _dbContext;
        public BookRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Books.CountAsync();
        }
        public IQueryable<Book> GetQueryable()
        {
            return _dbContext.Books.AsQueryable();
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await GetAsync(id);

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Book> GetAsync(Guid id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }


        public async Task<List<Book>> GetListAsync(int skipCount, int maxResultCount, string sorting)
        {
            var query = _dbContext.Books.AsQueryable();

            if (!string.IsNullOrEmpty(sorting))
            {
                query = query.OrderBy(sorting);
            }

            return await query.Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        public async Task<Book> InsertAsync(Book book)
        {
            var existingBook = await _dbContext.Books
                .FirstOrDefaultAsync(b => b.Id == book.Id);

            if (existingBook != null)
            {
                return existingBook;
            }

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }


        public async Task<Book?> UpdateAsync(Book book)
        {
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }
    }
}

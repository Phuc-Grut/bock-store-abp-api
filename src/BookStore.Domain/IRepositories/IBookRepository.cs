using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BookStore.IRepositories
{
    public interface IBookRepository 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> GetAsync(Guid id); // Get a book by ID
        Task<List<Book>> GetListAsync(int skipCount, int maxResultCount, string sorting);
        Task<Book> InsertAsync(Book book); // Insert a new book
        Task<Book?> UpdateAsync(Book book); // Update an existing book
        Task DeleteAsync(Guid id); // Delete a book by ID
        Task<int> CountAsync();
        IQueryable<Book> GetQueryable();
    }
}

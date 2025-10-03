using BookStore.Entities;
using BookStore.EntityFrameworkCore;
using BookStore.IRepositories;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;


namespace BookStore.Implement
{
    public class EducationRepository : IEducationRepository
    {
        private readonly BookStoreDbContext _context;
        public EducationRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> CountAsync()
        {
            return await _context.Educations.CountAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var education = await GetByIdAsync(id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
        }

        public async Task<Education> GetByIdAsync(Guid id)
        {
            var education = await _context.Educations.FirstOrDefaultAsync(e => e.Id == id);
            return education;
        }

        public Task<List<Education>> GetListAsync(int skipCount, int maxResultCount, string sorting)
        {
            var query = _context.Educations.AsQueryable();
            if (!string.IsNullOrEmpty(sorting))
            {
                query = query.OrderBy(sorting);
            }
            return query.Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        public async Task<Education> InsertAsync(Education education)
        {
            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();
            return education;
        }

        public Task<Education?> UpdateAsync(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChangesAsync();
            return Task.FromResult<Education?>(education);
        }
    }
}

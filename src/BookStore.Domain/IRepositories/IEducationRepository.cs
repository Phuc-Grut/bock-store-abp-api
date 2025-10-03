using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.IRepositories
{
    public interface IEducationRepository
    {
        Task<Education> GetByIdAsync(Guid id);
        Task<List<Education>> GetListAsync(int skipCount, int maxResultCount, string sorting);
        Task<Education> InsertAsync(Education education);
        Task<Education?> UpdateAsync(Education education);
        Task DeleteAsync(Guid id);
        Task<int> CountAsync();
    }
}

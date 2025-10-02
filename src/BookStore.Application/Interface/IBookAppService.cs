using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Interface
{
    public interface IBookAppService
    {
        Task<BookDto> GetAsync(Guid id);
        Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<BookDto> CreateAsync(CreateUpdateBookDto input);
        Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input);
        Task DeleteAsync(Guid id);
    }
}

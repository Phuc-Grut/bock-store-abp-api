using BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStore.Interface
{
    public interface IEducationAppServices
    {
        Task<EducationDto> GetAsync(Guid id);
        Task<PagedResultDto<EducationDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<EducationDto> CreateAsync(CreateUpdateEducationDto input);
        Task<EducationDto> UpdateAsync(Guid id, CreateUpdateEducationDto input);
        Task DeleteAsync(Guid id);
    }
}

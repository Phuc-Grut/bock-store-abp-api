using BookStore.DTO;
using BookStore.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStore.Controllers
{
    public class EducationController : BookStoreController
    {
        private readonly IEducationAppServices _educationAppService;
        public EducationController(IEducationAppServices educationApp)
        {
            _educationAppService = educationApp;
        }

        [HttpGet("api/app/education/{id}")]
        public async Task<EducationDto> GetBookAsync(Guid id)
        {
            var result = await _educationAppService.GetAsync(id);
            return result;
        }

        [HttpPost("api/app/education")]
        public async Task<EducationDto> CreateBookAsync([FromBody] CreateUpdateEducationDto input)
        {
            var result = await _educationAppService.CreateAsync(input);
            return result;
        }

        [HttpGet("api/app/education")]
        public async Task<PagedResultDto<EducationDto>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            var result = await _educationAppService.GetListAsync(input);
            return result;
        }

        [HttpDelete("api/app/education/{id}")]
        public async Task DeleteBookAsync(Guid id)
        {
            await _educationAppService.DeleteAsync(id);
            return;
        }

        [HttpPut("api/app/education/{id}")]
        public async Task<EducationDto> UpdateBookAsync(Guid id, [FromBody] CreateUpdateEducationDto input)
        {
            var result = await _educationAppService.UpdateAsync(id, input);
            return result;
        }
    }
}

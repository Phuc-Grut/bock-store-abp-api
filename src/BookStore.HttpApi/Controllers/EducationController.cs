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
        public async Task<ActionResult<EducationDto>> GetBookAsync(Guid id)
        {
            var result = await _educationAppService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("api/app/education")]
        public async Task<ActionResult<EducationDto>> CreateBookAsync([FromBody] CreateUpdateEducationDto input)
        {
            var result = await _educationAppService.CreateAsync(input);
            return Ok(result);
        }

        [HttpGet("api/app/education")]
        public async Task<ActionResult<PagedResultDto<EducationDto>>> GetListAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            var result = await _educationAppService.GetListAsync(input);
            return Ok(result);
        }

        [HttpDelete("api/app/education/{id}")]
        public async Task<IActionResult> DeleteBookAsync(Guid id)
        {
            await _educationAppService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("api/app/education/{id}")]
        public async Task<ActionResult<EducationDto>> UpdateBookAsync(Guid id, [FromBody] CreateUpdateEducationDto input)
        {
            var result = await _educationAppService.UpdateAsync(id, input);
            return Ok(result);
        }
    }
}

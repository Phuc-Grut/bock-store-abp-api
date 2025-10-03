using Asp.Versioning;
using BookStore.DTO;
using BookStore.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStore.Controllers
{
    //[Route("api/app/book")]
    [ControllerName("Book")]
    [ApiController]
    public class BookController : BookStoreController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppServices)
        {
            _bookAppService = bookAppServices;
        }


        [HttpGet("api/app/book")]
        public async Task<PagedResultDto<BookDto>> GetBooksAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _bookAppService.GetListAsync(input);
        }

        [HttpGet("api/app/book/{id}")]
        public async Task<BookDto> GetBookAsync(Guid id)
        {
            var result = await _bookAppService.GetAsync(id);
            return result;
        }

        [HttpPost("api/app/book")]
        public async Task<BookDto> CreateBookAsync([FromBody] CreateUpdateBookDto input)
        {
            var result = await _bookAppService.CreateAsync(input);
            return result;
        }
        [HttpPut("api/app/book/{id}")]
        public async Task<BookDto> UpdateBookAsync(Guid id, [FromBody] CreateUpdateBookDto input)
        {
            var result = await _bookAppService.UpdateAsync(id, input);
            return result;
        }
        [HttpDelete("api/app/book/{id}")]
        public async Task DeleteBookAsync(Guid id)
        {
            await _bookAppService.DeleteAsync(id);
            return;
        }

    }
}

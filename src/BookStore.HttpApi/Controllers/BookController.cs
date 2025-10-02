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
        public async Task<ActionResult<PagedResultDto<BookDto>>> GetBooksAsync([FromQuery] PagedAndSortedResultRequestDto input)
        {
            return await _bookAppService.GetListAsync(input);
        }

        [HttpGet("api/app/book/{id}")]
        public async Task<ActionResult<BookDto>> GetBookAsync(Guid id)
        {
            var result = await _bookAppService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost("api/app/book")]
        public async Task<ActionResult<BookDto>> CreateBookAsync([FromBody] CreateUpdateBookDto input)
        {
            var result = await _bookAppService.CreateAsync(input);
            return Ok(result);
        }
        [HttpPut("api/app/book/{id}")]
        public async Task<ActionResult<BookDto>> UpdateBookAsync(Guid id, [FromBody] CreateUpdateBookDto input)
        {
            var result = await _bookAppService.UpdateAsync(id, input);
            return Ok(result);
        }
        [HttpDelete("api/app/book/{id}")]
        public async Task<IActionResult> DeleteBookAsync(Guid id)
        {
            await _bookAppService.DeleteAsync(id);
            return NoContent();
        }

    }
}

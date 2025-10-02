using AutoMapper;
using BookStore.DTO;
using BookStore.Entities;
using BookStore.Interface;
using BookStore.IRepositories;
using BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BookStore.Implement;
[Authorize(BookStorePermissions.Books.Default)]

public class BookAppService : IBookAppService
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;
    //private readonly IAuthorizationService _authorizationService;

    public BookAppService(IBookRepository repository, IMapper mapper, IAuthorizationService authorizationService)
    {
        _repository = repository;
        _mapper = mapper;
        //_authorizationService = authorizationService;
    }
    [Authorize(BookStorePermissions.Books.Create)]
    public async Task<BookDto> CreateAsync(CreateUpdateBookDto input)
    {
        var book = _mapper.Map<Book>(input);

        await _repository.InsertAsync(book);
        return _mapper.Map<BookDto>(book);
    }

    [Authorize(BookStorePermissions.Books.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        var book = await _repository.GetAsync(id);
        if (book != null)
        {
            await _repository.DeleteAsync(id);
        }
    }

    [Authorize(BookStorePermissions.Books.Default)]
    public async Task<BookDto> GetAsync(Guid id)
    {
        //await _authorizationService.CheckAsync(BookStorePermissions.Books.Default);
        var book = await _repository.GetAsync(id);
        return _mapper.Map<BookDto>(book);
    }

    [Authorize(BookStorePermissions.Books.Default)]
    public async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var items = await _repository.GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);

        var result = _mapper.Map<List<BookDto>>(items);

        return new PagedResultDto<BookDto>(await _repository.CountAsync(), result);
    }

    [Authorize(BookStorePermissions.Books.Edit)]

    public async Task<BookDto> UpdateAsync(Guid id, CreateUpdateBookDto input)
    {
        //await _authorizationService.CheckAsync(BookStorePermissions.Books.Edit);

        var book = await _repository.GetAsync(id);

        _mapper.Map(input, book);


        await _repository.UpdateAsync(book);

        return _mapper.Map<BookDto>(book);
    }

}


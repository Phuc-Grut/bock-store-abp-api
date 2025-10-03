using BookStore.DTO;
using BookStore.Entities;
using BookStore.Interface;
using BookStore.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace BookStore.Implement
{
    public class EducationAppServices : IEducationAppServices
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IGuidGenerator _guidGenerator;
        //private readonly 
        public EducationAppServices(IEducationRepository educationRepository, IGuidGenerator guidGenerator)
        {
            _educationRepository = educationRepository;
            _guidGenerator = guidGenerator;
        }
        public async Task<EducationDto> CreateAsync(CreateUpdateEducationDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Degree))
            {
                throw new ArgumentException("Degree cannot be null or empty", nameof(input.Degree));
            }

            var education = new Education(
                _guidGenerator.Create(),
                input.Degree
            );

            await _educationRepository.InsertAsync(education);
            return new EducationDto
            {
                Degree = education.Degree,
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await _educationRepository.GetByIdAsync(id);
            if (book != null)
            {
                await _educationRepository.DeleteAsync(id);
            }
            else
            {
                throw new ArgumentException("Education not found", nameof(id));
            }
        }

        public async Task<EducationDto> GetAsync(Guid id)
        {
            var education = await _educationRepository.GetByIdAsync(id);
            if (education == null)
            {
                throw new ArgumentException("Education not found", nameof(id));
            }
            return new EducationDto
            {
                Degree = education.Degree,
                Status = education.Status,
            };
        }

        public async Task<PagedResultDto<EducationDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var (totalCount, items) = await _educationRepository
                .GetListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);

            var dtoList = items.ConvertAll(e => new EducationDto
            {
                Id = e.Id,
                Degree = e.Degree,
                Status = e.Status,
            });

            return new PagedResultDto<EducationDto>(totalCount, dtoList);
        }


        public async Task<EducationDto> UpdateAsync(Guid id, CreateUpdateEducationDto input)
        {
            var education = await  _educationRepository.GetByIdAsync(id);
            if (education == null)
            {
                throw new ArgumentException("Education not found", nameof(id));
            }
            education.Degree = input.Degree ?? education.Degree;
            await _educationRepository.UpdateAsync(education);
            return new EducationDto
            {
                Degree = education.Degree,
            };
        }
    }
}

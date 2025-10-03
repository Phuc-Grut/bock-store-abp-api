using BookStore.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BookStore.DTO
{
    public class EducationDto : AuditedEntityDto<Guid>
    {
        public string Degree { get; set; }
        public EducationStatus Status { get; set; }
    }

    public class CreateUpdateEducationDto
    {
        [Required]
        [StringLength(128)]
        public string Degree { get; set; }
    }
}

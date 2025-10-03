using BookStore.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace BookStore.Entities
{
    public class Education : AggregateRoot<Guid>
    {
        public string? Degree { get; set; }
        public ICollection<AppUser> Users { get; set; } = new List<AppUser>();
        public EducationStatus Status { get; set; } = EducationStatus.Active;

        public Education(Guid id, string degree) : base(id)
        {
            Degree = degree;
        }

        protected Education()
        {
        }
    }
}

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
    }
}

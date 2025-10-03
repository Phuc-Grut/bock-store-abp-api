using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace BookStore.Entities
{
    public class AppUser : IdentityUser
    {
        public Guid? EducationId { get; set; }
        public Education? Education { get; set; }
    }
}

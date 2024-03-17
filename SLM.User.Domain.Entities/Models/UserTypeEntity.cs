using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class UserTypeEntity : BaseEntity
    {
        public string TypeName { get; set; }
        public string Description { get; set; }

        public List<UserEntity> Users { get; set; }
    }
}

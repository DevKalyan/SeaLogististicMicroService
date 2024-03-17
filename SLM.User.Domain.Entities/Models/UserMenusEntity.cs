using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class UserMenusEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string AllocatedMenus { get; set; }

        //RelationShip

        public UserEntity User { get; set; }
    }
}

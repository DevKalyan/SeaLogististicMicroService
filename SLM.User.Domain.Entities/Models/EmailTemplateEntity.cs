using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class EmailTemplateEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        //the configuration ensures that for each user, there is one job title, and each job title can have multiple users. 
        public ICollection<UserEntity> Users { get; set; }
    }
}

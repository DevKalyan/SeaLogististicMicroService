using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class BaseEntity
    {
        public Guid EntityID { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}

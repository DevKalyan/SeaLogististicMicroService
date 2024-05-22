using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.Models

{
    public class BaseModel
    {
        public Guid UniqueID { get; set; }
        public DateTime CreatedDt { get; set; }
        public Guid CreateUserId { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid ModifiedUserId { get; set; }
        public int IsDeleted { get; set; }
    }
}

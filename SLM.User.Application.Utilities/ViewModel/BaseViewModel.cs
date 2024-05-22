using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.ViewModel
{
    public class BaseViewModel
    {
        public Guid PrimaryId { get; set;}
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public int IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class MenuItemsEntity : BaseEntity
    {
        public string ParentMenuCode { get; set; } // Foreign key
        public string MenuItemCode { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string MenuUrl { get; set; }
        public int MenuOrder { get; set; }

        public MenuEntity Menu { get; set; } // Navigation property


    }
}

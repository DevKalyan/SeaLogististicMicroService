using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class MenuEntity : BaseEntity
    {
        public string MenuCode { get; set; }
        public string MenuHeader { get; set; }
        public int MenuOrder { get; set; }

        //Relation ship

        public List<MenuItemsEntity> MenuItems { get; set; }
    }
}

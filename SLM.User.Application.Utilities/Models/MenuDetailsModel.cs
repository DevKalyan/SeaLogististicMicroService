using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.Models
{
    public class MenuDetailsModel
    {
        public string MenuHeaderCode { get; set; } // Foreign key
        public string MenuDetailsCode { get; set; }
        public string MenuDetailsName { get; set; }
        public string MenuDetailsDescription { get; set; }
        public string MenuDetailsUrl { get; set; }
        public int MenuDetailsOrder { get; set; }
    }
}

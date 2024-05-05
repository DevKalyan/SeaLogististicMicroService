using SLM.User.Application.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.ViewModel
{
    public class MenuViewModel
    {
        public string MenuHeaderCode { get; set; }
        public string MenuHeaderName { get; set; }
        public int MenuHeaderOrder { get; set; }
        public List<MenuDetailsModel> MenuDetails { get; set; }
    }
}

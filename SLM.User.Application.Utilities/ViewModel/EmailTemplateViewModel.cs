using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.ViewModel
{
    public class EmailTemplateViewModel : BaseViewModel
    {

        public string TemplateCode { get; set; }
        public string TemplateName { get; set; }
        public string TemplateDescription { get; set; }
        public string Template { get; set; }
    }
}

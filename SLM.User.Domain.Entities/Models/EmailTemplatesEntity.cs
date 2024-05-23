using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class EmailTemplatesEntity : BaseEntity
    {
        public string EmailTemplateCode { get; set; }
        public string EmailTemplateName { get; set; }
        public string EmailTemplateDesc { get; set; }
        public string EmailTemplate { get; set; }
    }
}

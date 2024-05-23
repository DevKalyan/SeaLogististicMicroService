using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Infrastructure.Persistence.ViewModels
{
    public class EmailViewModel
    {
        public string RecieptentEmaails { get; set; }
        public string SenderEmail { get; set; }
        public string RecieptentCCemails { get; set; }
        public string RecieptentBCCemails { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }       
        public List<string> AttachmentList { get; set; }
    }
}

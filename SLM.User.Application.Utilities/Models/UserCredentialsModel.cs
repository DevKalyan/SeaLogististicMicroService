using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.Models
{
    public class UserCredentialsModel : BaseModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int PasswordChanged { get; set; }
        public DateTime DtPasswordChanged { get; set; }        
    }
}

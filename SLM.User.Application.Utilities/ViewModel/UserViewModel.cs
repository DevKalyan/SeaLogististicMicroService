using SLM.User.Application.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public Guid UserId { get; set; }
        public UserBasicDetailsModel UserBasicDetails { get; set; }
        public UserCredentialsModel UserCredentials { get; set; }

        public UserMenuModel UserMenuDetails { get; set; }
    }
}

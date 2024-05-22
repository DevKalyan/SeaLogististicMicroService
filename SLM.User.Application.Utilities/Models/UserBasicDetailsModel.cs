using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Application.Utilities.Models
{
    public class UserBasicDetailsModel 
    {
        public string User_FirstName { get; set; }
        public string User_MiddleName { get; set; }
        public string User_LastName { get; set; }
        public string User_Email { get; set; }
        public Guid User_Designation { get; set; }

        public Guid User_Type { get; set; }
        public string User_Country { get; set; }
        public string User_State { get; set; }
        public string User_PostalCode { get; set; }
        public string User_PhoneNumber { get; set; }
        public DateTime User_DateOfBirth { get; set; }        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Exceptions
{
    public class DuplicateUsernameException : Exception
    {
        public DuplicateUsernameException(string message) : base(message)
        {
        }
    }
}

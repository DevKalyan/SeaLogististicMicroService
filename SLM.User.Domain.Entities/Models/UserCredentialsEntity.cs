using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class UserCredentialEntity : BaseEntity
    {

        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public int PasswordChanged { get; set; }
        public DateTime DtPasswordChanged { get; set; }

        // Relation ship
        public int UserId { get; set; }
        public UserEntity User { get; set; }

    }
}

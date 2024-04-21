using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class UserEntity : BaseEntity
    {
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Relation ship
        public Guid UserTypeId { get; set; }
        public UserTypeEntity UserType { get; set; }
        public Guid DesignationId { get; set; }
        public DesignationEntity Designation { get; set; }

        public UserCredentialEntity UserCredential { get; set; }
        public UserMenusEntity UserMenu { get; set; }

    }
}

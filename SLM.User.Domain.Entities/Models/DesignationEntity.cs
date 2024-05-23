using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.User.Domain.Entities.Models
{
    public class DesignationEntity : BaseEntity
    {
        public string DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public string DesignationDesc { get; set; }

        public List<UserEntity> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserInValidationDto
    {
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
    }
}

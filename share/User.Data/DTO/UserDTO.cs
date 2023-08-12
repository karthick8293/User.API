using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Data.DTO
{
    public class UserDTO
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public int userAge { get; set; }
        public string userGender { get; set; }
        public string eMailId { get; set; }
        public string phoneNumber { get; set; }
        public string country { get; set; }
        public string states { get; set; }
        public bool isActive { get; set; }
    }
}

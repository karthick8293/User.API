using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Data.DBModel
{
    public class UserInformations
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public string UserGender { get; set; }
        public string EMailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string States { get; set; }
        public bool IsActive { get; set; }
        public int CreatedOn { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedOn { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? DeletedOn { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}

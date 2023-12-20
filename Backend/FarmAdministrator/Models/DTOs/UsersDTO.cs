using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class UsersDTO
    {
        public int IdUser { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int UserRole { get; set; }
        public int UserType { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string Adress { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int State { get; set; }
    }
}

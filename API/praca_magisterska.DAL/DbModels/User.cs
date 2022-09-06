using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praca_magisterska.DAL.DbModels
{
    public partial class User
    {
        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BornDate { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long? ClassID { get; set; }
        public long? RoleID { get; set; }


        public virtual Class Class { get; set; }
        public virtual Role Role { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praca_magisterska.DAL.DbModels
{
    public partial class Role
    {
        public long RoleID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public virtual User User { get; set; }

    }
}

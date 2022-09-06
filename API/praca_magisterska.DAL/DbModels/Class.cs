using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praca_magisterska.DAL.DbModels
{
    public partial class Class
    {
        public long ClassID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public virtual List<User> Users { get; set; }

    }
}

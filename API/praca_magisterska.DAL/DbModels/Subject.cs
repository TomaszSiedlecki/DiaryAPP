using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praca_magisterska.DAL.DbModels
{
    public partial class Subject
    {
        public long SubjectID { get; set; }
        public string Name { get; set; }
        public long ClassID { get; set; }

    }
}

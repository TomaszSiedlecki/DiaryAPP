using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praca_magisterska.DAL.DbModels
{
    public partial class Grade
    {
        public long GradeID { get; set; }
        public string Name { get; set; }
        public long SubjectID { get; set; }
        public long StudentID { get; set; }
        public long TeacherID { get; set; }

    }
}
